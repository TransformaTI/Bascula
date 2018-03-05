using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets ;
using System.IO.Ports;
using System.Threading;

using LeerPesoBascula;

namespace Project01
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{        
		private System.Windows.Forms.TextBox txtDataRx;
		private System.Windows.Forms.Button cmdReceiveData;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.GroupBox groupBox2;
        private Button cmdCom;
        private TextBox txtCom;
        private GroupBox groupBox3;
        private TextBox txtBaut;
        private Label label3;
        private TextBox txtPuertoCom;
        private Label label4;
        private TextBox txtBits;
        private Label label5;
        private Label label6;
        private ComboBox cmbParidad;
        private GroupBox gbCadena;
        private TextBox txtInicio;
        private Label lblInicio;
        private Button cmdConectar;
        private TextBox txtLongitud;
        private Label lblLongitud;
        private TextBox txtCaracter;
        private Label label7;
        private ComboBox cmbFlujo;
        private Label label8;
        private ComboBox cmbParada;
        private Label label9;
        private TextBox txtEmpresa;
        private Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;       

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtDataRx = new System.Windows.Forms.TextBox();
            this.cmdReceiveData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdCom = new System.Windows.Forms.Button();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbParada = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFlujo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbParidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBaut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPuertoCom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCadena = new System.Windows.Forms.GroupBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.txtCaracter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.cmdConectar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbCadena.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataRx
            // 
            this.txtDataRx.Location = new System.Drawing.Point(9, 19);
            this.txtDataRx.Multiline = true;
            this.txtDataRx.Name = "txtDataRx";
            this.txtDataRx.Size = new System.Drawing.Size(318, 56);
            this.txtDataRx.TabIndex = 4;
            // 
            // cmdReceiveData
            // 
            this.cmdReceiveData.Location = new System.Drawing.Point(333, 19);
            this.cmdReceiveData.Name = "cmdReceiveData";
            this.cmdReceiveData.Size = new System.Drawing.Size(56, 56);
            this.cmdReceiveData.TabIndex = 5;
            this.cmdReceiveData.Text = "Get Ethernet";
            this.cmdReceiveData.Click += new System.EventHandler(this.cmdReceiveData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(128, 48);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "1702";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(72, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port :";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(128, 16);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(120, 20);
            this.txtIPAddress.TabIndex = 2;
            this.txtIPAddress.Text = "192.168.0.1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host I.P. Address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdReceiveData);
            this.groupBox2.Controls.Add(this.txtDataRx);
            this.groupBox2.Location = new System.Drawing.Point(8, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 87);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // cmdCom
            // 
            this.cmdCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCom.Location = new System.Drawing.Point(8, 411);
            this.cmdCom.Name = "cmdCom";
            this.cmdCom.Size = new System.Drawing.Size(76, 56);
            this.cmdCom.TabIndex = 8;
            this.cmdCom.Text = "Procesar COM";
            this.cmdCom.UseVisualStyleBackColor = true;
            this.cmdCom.Click += new System.EventHandler(this.cmdCom_Click);
            // 
            // txtCom
            // 
            this.txtCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCom.Location = new System.Drawing.Point(90, 411);
            this.txtCom.Multiline = true;
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(307, 56);
            this.txtCom.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbParada);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cmbFlujo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbParidad);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtBits);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtBaut);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPuertoCom);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(8, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 101);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port COM Setting";
            // 
            // cmbParada
            // 
            this.cmbParada.FormattingEnabled = true;
            this.cmbParada.Location = new System.Drawing.Point(100, 68);
            this.cmbParada.Name = "cmbParada";
            this.cmbParada.Size = new System.Drawing.Size(92, 21);
            this.cmbParada.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Bits de Parada:";
            // 
            // cmbFlujo
            // 
            this.cmbFlujo.FormattingEnabled = true;
            this.cmbFlujo.Location = new System.Drawing.Point(299, 68);
            this.cmbFlujo.Name = "cmbFlujo";
            this.cmbFlujo.Size = new System.Drawing.Size(92, 21);
            this.cmbFlujo.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(205, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Control de Flujo:";
            // 
            // cmbParidad
            // 
            this.cmbParidad.FormattingEnabled = true;
            this.cmbParidad.Location = new System.Drawing.Point(299, 42);
            this.cmbParidad.Name = "cmbParidad";
            this.cmbParidad.Size = new System.Drawing.Size(92, 21);
            this.cmbParidad.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(205, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Paridad:";
            // 
            // txtBits
            // 
            this.txtBits.Location = new System.Drawing.Point(299, 16);
            this.txtBits.Name = "txtBits";
            this.txtBits.Size = new System.Drawing.Size(92, 20);
            this.txtBits.TabIndex = 6;
            this.txtBits.Text = "7";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(205, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bits de datos:";
            // 
            // txtBaut
            // 
            this.txtBaut.Location = new System.Drawing.Point(100, 42);
            this.txtBaut.Name = "txtBaut";
            this.txtBaut.Size = new System.Drawing.Size(92, 20);
            this.txtBaut.TabIndex = 4;
            this.txtBaut.Text = "2400";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bits/Segundo:";
            // 
            // txtPuertoCom
            // 
            this.txtPuertoCom.Location = new System.Drawing.Point(100, 16);
            this.txtPuertoCom.Name = "txtPuertoCom";
            this.txtPuertoCom.Size = new System.Drawing.Size(92, 20);
            this.txtPuertoCom.TabIndex = 2;
            this.txtPuertoCom.Text = "COM1";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Puerto COM:";
            // 
            // gbCadena
            // 
            this.gbCadena.Controls.Add(this.txtEmpresa);
            this.gbCadena.Controls.Add(this.label10);
            this.gbCadena.Controls.Add(this.txtLongitud);
            this.gbCadena.Controls.Add(this.lblLongitud);
            this.gbCadena.Controls.Add(this.txtCaracter);
            this.gbCadena.Controls.Add(this.label7);
            this.gbCadena.Controls.Add(this.txtInicio);
            this.gbCadena.Controls.Add(this.lblInicio);
            this.gbCadena.Location = new System.Drawing.Point(8, 294);
            this.gbCadena.Name = "gbCadena";
            this.gbCadena.Size = new System.Drawing.Size(402, 75);
            this.gbCadena.TabIndex = 11;
            this.gbCadena.TabStop = false;
            this.gbCadena.Text = "Parámetros Lectura Cadena";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(288, 45);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(92, 20);
            this.txtEmpresa.TabIndex = 7;
            this.txtEmpresa.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Empresa:";
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(288, 19);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(92, 20);
            this.txtLongitud.TabIndex = 5;
            this.txtLongitud.Text = "5";
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.Location = new System.Drawing.Point(194, 22);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(91, 13);
            this.lblLongitud.TabIndex = 4;
            this.lblLongitud.Text = "Longitud Cadena:";
            // 
            // txtCaracter
            // 
            this.txtCaracter.Location = new System.Drawing.Point(100, 45);
            this.txtCaracter.Name = "txtCaracter";
            this.txtCaracter.Size = new System.Drawing.Size(70, 20);
            this.txtCaracter.TabIndex = 3;
            this.txtCaracter.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Caracter Inicial:";
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(100, 19);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(70, 20);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.Text = "2";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(6, 22);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(86, 13);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Posoicion Inicial:";
            // 
            // cmdConectar
            // 
            this.cmdConectar.Location = new System.Drawing.Point(159, 375);
            this.cmdConectar.Name = "cmdConectar";
            this.cmdConectar.Size = new System.Drawing.Size(97, 25);
            this.cmdConectar.TabIndex = 12;
            this.cmdConectar.Text = "Abrir COM";
            this.cmdConectar.UseVisualStyleBackColor = true;
            this.cmdConectar.Click += new System.EventHandler(this.cmdConectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(419, 479);
            this.Controls.Add(this.cmdConectar);
            this.Controls.Add(this.gbCadena);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtCom);
            this.Controls.Add(this.cmdCom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbCadena.ResumeLayout(false);
            this.gbCadena.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private LeerPesoBascula.AbrirEthernet COM;
       
		private void cmdReceiveData_Click(object sender, System.EventArgs e)
		{
            //Puerto Ethernet
            COM = new LeerPesoBascula.AbrirEthernet(); 
            COM.ResultadoValidacion = "";
            COM.AbirConexion(this.txtIPAddress.Text,this.txtPort.Text);
            COM.ObtenerDatos();
            COM.CerrarConexion();
            this.txtCom.Text = COM.ResultadoValidacion;
            this.txtDataRx.Text = COM.ValidarCadena(4,int.Parse(this.txtInicio.Text), int.Parse(this.lblLongitud.Text), 
                this.txtCaracter.Text.Trim());
		}
        
        private void cmdCom_Click(object sender, EventArgs e)
        {
            //frmLeerCOM Uno = new frmLeerCOM();

            COM = new AbrirEthernet(); //Instancia de la clase

            COM.ResultadoValidacion = this.txtDataRx.Text;
            this.txtCom.Text = COM.ValidarCadena(int.Parse(this.txtEmpresa.Text.Trim()), int.Parse(this.txtInicio.Text), 
                int.Parse(this.txtLongitud.Text), this.txtCaracter.Text.Trim());
        }

        private SerialPort port;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbParidad.Items.Add("Ninguno");
            this.cmbParidad.Items.Add("Par");
            this.cmbParidad.Items.Add("Impar");

            this.cmbParidad.SelectedIndex = 0;

            this.cmbFlujo.Items.Add("Ninguno");
            this.cmbFlujo.Items.Add("Hadware");
            this.cmbFlujo.Items.Add("XOn/XOff");

            this.cmbFlujo.SelectedIndex = 1;

            this.cmbParada.Items.Add("Ninguno");
            this.cmbParada.Items.Add("1");
            this.cmbParada.Items.Add("1.5");
            this.cmbParada.Items.Add("2");

            this.cmbParada.SelectedIndex = 0;
        }

        private void cmdConectar_Click(object sender, EventArgs e)
        {
            //port = new SerialPort(this.txtPuertoCom.Text, int.Parse(this.txtBaut.Text), Parity.None,
                //int.Parse(this.txtBits.Text), StopBits.One);                       

            port = new SerialPort();

            port.PortName = this.txtPuertoCom.Text;
            port.BaudRate = int.Parse(this.txtBaut.Text.Trim());
            port.DataBits = int.Parse(this.txtBits.Text.Trim());

            //Control de paridad
            switch (this.cmbParidad.SelectedIndex){
                case 0:
                    this.port.Parity = Parity.None;
                break;
                case 1:
                    this.port.Parity = Parity.Even;
                break;
                case 2:
                    this.port.Parity = Parity.Mark;
                break;
            }

            //Control de StopBit
            switch (this.cmbParada.SelectedIndex)
            {
                case 0:
                    this.port.StopBits = StopBits.None;
                    break;
                case 1:
                    this.port.StopBits = StopBits.One;
                    break;
                case 2:
                    this.port.StopBits = StopBits.OnePointFive;
                    break;
                case 3:
                    this.port.StopBits = StopBits.Two;
                    break;
            }

            //Control de Flujo
            switch (this.cmbFlujo.SelectedIndex)
            {
                case 0:
                    this.port.Handshake = Handshake.None;
                    break;
                case 1:
                    this.port.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                case 2:
                    this.port.Handshake = Handshake.XOnXOff;
                    break;
            }

            port.DtrEnable = true;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.DiscardNull = true;

            if (port.IsOpen == false)
                try
                {
                    port.Open();
                }
                catch (Exception oex)
                {
                    MessageBox.Show(oex.ToString() + "\n" + oex.Message, "Error al abrir el puerto");
                }
        }

        private void DoUpdate(object s, EventArgs e)
        {
            Thread.Sleep(100);

            string data = port.ReadExisting() + port.ReadExisting(); //+port.ReadExisting();

            if (data.Trim().Length > 3)
            {
                try
                {
                    this.txtDataRx.Text = data.Trim().Remove(0, 3);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message.ToString(), "Error al obtener la cadena");
                }
            }
            else
                MessageBox.Show(data, "Información obtenida");
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
            //port.Close();
        }

 	}
}
