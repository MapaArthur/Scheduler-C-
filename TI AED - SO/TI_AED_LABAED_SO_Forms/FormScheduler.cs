using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using CircularProgressBar;
using System.Threading;


namespace TI_AED_LABAED_SO_Forms
{
    public partial class FormScheduler : MetroForm
    {
        Thread aux1, aux2;
        bool exit = false;
        public FormScheduler()
        {
            InitializeComponent();
            DataBase.CarregarDados("../../BancoDeDados.txt");
            VerListExecucao();
            VerListsPrioridades();

        }

        /// <summary>
        /// Método que preenche a listView com os processos em execução.
        /// </summary>
        private void VerListExecucao()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { VerListExecucao(); }));
            }
            else
            {
                listViewExecucao.Items.Clear();
                string[] aux = Scheduler.ListaExecucao.ToString().Split(';');
                for (int i = 0; i < aux.Length - 4; i += 5)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = (aux[i]);
                    item.SubItems.Add(aux[i + 1]);
                    item.SubItems.Add(aux[i + 2]);
                    item.SubItems.Add(aux[i + 3]);
                    item.SubItems.Add(aux[i + 4]);
                    listViewExecucao.Items.Add(item);
                }
            }
        }

        private void ThreadExecutarLista()
        {
            do
            {
                Monitor.Enter(aux1);
                try
                {
                    Scheduler.ExecutaListadeExecucao();
                }
                catch (ArgumentException)
                {
                    exit = true;
                    MessageBox.Show("Processos finalizados!");
                    aux1.Abort();
                    aux2.Abort();
                }
                finally
                {
                    Monitor.Exit(aux1);
                }

            } while (!exit);

        }

        private void ThreadAtualizarLista()
        {
            do
            {
                VerListsPrioridades();
                VerListExecucao();
                Thread.Sleep(800);
            } while (!exit);
        }

        /// <summary>
        /// Método que carrega todos os processos para as respectivas ListViews.
        /// </summary>
        private void VerListsPrioridades()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { VerListsPrioridades(); }));
            }
            else
            {
                ClearList();
                string[] aux;
                if (!Scheduler.ListaPrioridade1.Empty())
                {
                    aux = Scheduler.ListaPrioridade1.ToString().Split(';');
                    for (int i = 0; i < aux.Length - 4; i += 5)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (aux[i]);
                        item.SubItems.Add(aux[i + 1]);
                        item.SubItems.Add(aux[i + 2]);
                        item.SubItems.Add(aux[i + 3]);
                        item.SubItems.Add(aux[i + 4]);
                        listView1.Items.Add(item);
                    }
                }
                if (!Scheduler.ListaPrioridade2.Empty())
                {
                    aux = Scheduler.ListaPrioridade2.ToString().Split(';');
                    for (int i = 0; i < aux.Length - 4; i += 5)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (aux[i]);
                        item.SubItems.Add(aux[i + 1]);
                        item.SubItems.Add(aux[i + 2]);
                        item.SubItems.Add(aux[i + 3]);
                        item.SubItems.Add(aux[i + 4]);
                        listView2.Items.Add(item);
                    }
                }
                if (!Scheduler.ListaPrioridade3.Empty())
                {
                    aux = Scheduler.ListaPrioridade3.ToString().Split(';');
                    for (int i = 0; i < aux.Length - 4; i += 5)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (aux[i]);
                        item.SubItems.Add(aux[i + 1]);
                        item.SubItems.Add(aux[i + 2]);
                        item.SubItems.Add(aux[i + 3]);
                        item.SubItems.Add(aux[i + 4]);
                        listView3.Items.Add(item);
                    }
                }
                if (!Scheduler.ListaPrioridade4.Empty())
                {
                    aux = Scheduler.ListaPrioridade4.ToString().Split(';');
                    for (int i = 0; i < aux.Length - 4; i += 5)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (aux[i]);
                        item.SubItems.Add(aux[i + 1]);
                        item.SubItems.Add(aux[i + 2]);
                        item.SubItems.Add(aux[i + 3]);
                        item.SubItems.Add(aux[i + 4]);
                        listView4.Items.Add(item);
                    }
                }
                if (!Scheduler.ListaPrioridade5.Empty())
                {
                    aux = Scheduler.ListaPrioridade5.ToString().Split(';');
                    for (int i = 0; i < aux.Length - 4; i += 5)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (aux[i]);
                        item.SubItems.Add(aux[i + 1]);
                        item.SubItems.Add(aux[i + 2]);
                        item.SubItems.Add(aux[i + 3]);
                        item.SubItems.Add(aux[i + 4]);
                        listView5.Items.Add(item);
                    }
                }
            }
        }

        //public async Task AtualizarAsync()
        //{
        //    //Criando delegate para execução de uma Thread que atualizará as listas de exibição async. (Utilizando função lambda)
        //    //Thread trdAt = new Thread(new ThreadStart(ThreadAtualizarLista));
        //    await Task.Run(() => trdAt.Start());
        //    //aux2 = trdAt;
        //}

        private void start_Click(object sender, EventArgs e)
        {
            //Criando duas Threads de execução para simular um CPU 0 e CPU 1.
            Thread trdEx = new Thread(new ThreadStart(ThreadExecutarLista));
            Thread trdExB = new Thread(new ThreadStart(ThreadExecutarLista));
            Thread trdAt = new Thread(new ThreadStart(ThreadAtualizarLista));
            //trdEx.Name = "1";
            //trdExB.Name = "2";
            
            //Set dos ponteiros para as Threads
            aux1 = trdEx;
            aux2 = trdAt;

            Task.Run(() =>
            {
                trdEx.Start();
                trdExB.Start();
                trdAt.Start();
            }).Wait();

            

            //Task.Run(async () =>
            //{
            //    trdEx.Start();//CPU 0
            //    trdExB.Start();//CPU 1
            //    await AtualizarAsync();//Aguarda a execução da função assíncrona de atualização das ListViews
            //}).Wait();//Aguarda a Task ser executada completamente.
        }

        private void ClearList()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { VerListExecucao(); }));
            }
            else
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();
                listView5.Items.Clear();
            }
        }

        private void FormScheduler_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                aux1.Abort();
                aux2.Abort();
                ClearList();
            }
            catch (Exception)
            {
                Application.Exit();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInformation formInformation = new FormInformation();
            formInformation.Show();
        }

        private void FormScheduler_Load(object sender, EventArgs e)
        {

        }
    }
}
