using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using BL;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Net;
 

namespace StockVentas
{
    public partial class frmPruebas : Form
    {
        [DllImport("user32.dll", SetLastError = true)] //dll necesaria para matar proceso excel
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);  //dll necesaria para matar proceso excel

        Excel.Application app = new Excel.Application();
        Excel.Workbook libro;

        public frmPruebas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tblArticulos = BL.GetDataBLL.GetArticulos();
            /*   int i = 0;
               for (i = 0; i < 10; i++)
               { 
            
               }*/
            Cursor.Current = Cursors.WaitCursor;
            foreach (DataRow row in tblArticulos.Rows)
            {
                string oldId = row["IdArticuloART"].ToString();
                string id = "0" + oldId;
                BL.ArticulosBLL.ActualizarArticulos(id, oldId);
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void killExcel()
        {
            IntPtr hwnd = new IntPtr(app.Hwnd);
            IntPtr processId;
            IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
            Process proc = Process.GetProcessById(processId.ToInt32());
            proc.Kill(); // set breakpoint here and watch the Windows Task Manager kill this exact EXCEL.EXE            
        }        

        private void frmPruebas_FormClosing(object sender, FormClosingEventArgs e)
        {
            killExcel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string line;

            // Read the file and display it line by line.
            ArrayList db = new ArrayList();
            System.IO.StreamReader file = new System.IO.StreamReader("n:\\ncsoftwa_re.sql");
            while ((line = file.ReadLine()) != null)
            {
                db.Add(line);
            }
            foreach (object o in db)
            {
                string linea = o.ToString();
                if (linea.Contains("ncsoftwa_re"))
                {

                    //aqui reemplazas

                }
            }
            file.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Benja\\Desktop\\liquidacion.xlsx;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\";";
            OleDbConnection con = new OleDbConnection(Connection);
            System.Data.DataTable tblPrecioNuevos = new System.Data.DataTable();
            OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [Hoja2$]", con);
            myCommand.Fill(tblPrecioNuevos);
            DataTable tblArticulos = BL.GetDataBLL.Articulos();
            foreach (DataRow rowPreciosNuevos in tblPrecioNuevos.Rows)
            {
                string articulo = rowPreciosNuevos["Articulo"].ToString();
                if(!string.IsNullOrEmpty(articulo))
                {
                    if (articulo.Length == 8)
                        articulo = "00" + articulo;
                    if (articulo.Length == 9)
                        articulo = "0" + articulo;
                  //  articulo = rowPreciosNuevos["Articulo"].ToString().Substring(0, rowPreciosNuevos["Articulo"].ToString().Length - 4);
                    articulo = articulo.Substring(0, articulo.Length - 4);
                    DataRow[] foundRow = tblArticulos.Select("IdArticuloART LIKE '" + articulo + "*'");
                    foreach (DataRow rowArticulos in foundRow)
                    {
                        rowArticulos["PrecioPublicoART"] = rowPreciosNuevos["Makro"].ToString();
                        rowArticulos["PrecioMayorART"] = rowPreciosNuevos["Jesus"].ToString();
                    }                
                }
            }
            if (tblArticulos.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblArticulos, "frmArticulosGenerar", "grabar");
                progreso.ShowDialog();
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void btnCompararStock_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Benja\\Desktop\\libro1.xlsx;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\";";
            OleDbConnection con = new OleDbConnection(Connection);
            System.Data.DataTable tblOriginal = new System.Data.DataTable();
            OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [original$]", con);
            myCommand.Fill(tblOriginal);
            System.Data.DataTable tblModificado = new System.Data.DataTable();
            myCommand = new OleDbDataAdapter("select * from [modificado$]", con);
            myCommand.Fill(tblModificado);
            int contador = 0;
            ArrayList miArray = new ArrayList();
            foreach (DataRow rowOriginal in tblOriginal.Rows)
            {
                string articulo = rowOriginal["Articulo"].ToString();
                DataRow[] rowfound = tblModificado.Select("Articulo LIKE '" + articulo + "'");
                if (rowfound.Count() == 0)
                {
                    miArray.Add(articulo);
                }
                foreach (DataRow rowModificado in rowfound)
                {
                    string originalMakro = rowOriginal["Makro"].ToString();
                    string modificadoMakro = rowModificado["Makro"].ToString();
                    string originalJesus = rowOriginal["Jesus Maria"].ToString();
                    string modificadoJesus = rowModificado["Jesus Maria"].ToString();
                    if (originalMakro != modificadoMakro || originalJesus != modificadoJesus)
                        MessageBox.Show(rowOriginal["Articulo"].ToString());
                }
                contador++;
            }
            MessageBox.Show(contador.ToString());
            Cursor.Current = Cursors.Arrow;
        }

        private void txtWebRequest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Benja\\Desktop\\clientes_face.xlsx;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\";";
            OleDbConnection con = new OleDbConnection(Connection);
            System.Data.DataTable tblClientesFace = new System.Data.DataTable();
            OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [clientes$]", con);
            myCommand.Fill(tblClientesFace);

            DataTable tblClientes = BL.GetDataBLL.Clientes();
            int clientesAntes = tblClientes.Rows.Count;
            int clave;
            foreach (DataRow rowClientesFace in tblClientesFace.Rows)
            {
                string clienteFace = rowClientesFace["E-mail"].ToString();
                DataRow[] foundRow = tblClientes.Select("CorreoCLI LIKE '" + clienteFace + "'");
                if (foundRow.Count() > 0)
                {
                    DataRow rowCliente = tblClientes.NewRow();
                    Random rand = new Random();
                    clave = rand.Next(1000000000, 2000000000);
                    rowCliente["IdClienteCLI"] = clave;
                    rowCliente["NombreCLI"] = rowClientesFace["Nombre"].ToString().ToUpper();
                    rowCliente["ApellidoCLI"] = rowClientesFace["Apellido"].ToString().ToUpper();
                    rowCliente["CorreoCLI"] = rowClientesFace["E-mail"].ToString();
                    tblClientes.Rows.Add(rowCliente);
                }
            }
            int clientesDespues = tblClientes.Rows.Count;
            if (tblClientes.GetChanges() != null)
            {
                frmProgress progreso = new frmProgress(tblClientes, "frmClientes", "grabar");
                progreso.ShowDialog();
            }
            Cursor.Current = Cursors.Arrow;
            
        }

        private void btnUploadImagen_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            DAL.AlicuotasIvaDAL.SaveImage(ms);
            
        }
    }
}

