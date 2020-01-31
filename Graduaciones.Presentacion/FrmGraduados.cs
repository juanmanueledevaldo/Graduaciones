using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graduaciones.Negocio;

namespace Graduaciones.Presentacion
{
    public partial class FrmGraduados : Form
    {
        public FrmGraduados()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NGraduado.Listar();
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total de registros: " + Convert.ToString(DgvListado.Rows.Count);   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);   
            }
        }

        private void Formato()
        {

            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = true;
            DgvListado.Columns[2].Width = 100;
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[7].Width = 100;
            DgvListado.Columns[8].Width = 100;
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;

        }

        private void Limpiar()
        {
            TxtBuscarNombre.Clear();
            TxtGeneracion.Clear();
            TxtGrupo.Clear();
            TxtInstituto.Clear();
            TxtNombre.Clear();
            TxtTurno.Clear();
            TxtAbono.Clear();
            TxtId.Clear();
            BtnAgregar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();

            DgvListado.Columns[0].Visible = false;
            BtnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Graduaciones Del Noroeste", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Graduaciones Del Noroeste", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarFoto()
        {
           try
            {
                CboFoto.DataSource = NFoto.Listar();
                CboFoto.DisplayMember = "individual";
                CboFoto.ValueMember = "idFoto";               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CargarAnillo()
        {
            CboAnillo.DataSource = NAnillo.Listar();
            CboAnillo.DisplayMember = "tamanoAnillo";
            CboAnillo.ValueMember = "idAnillo";
        }

        private void CargarCuadro()
        {
            CboCuadro.DataSource = NCuadro.Listar();
            CboCuadro.DisplayMember = "tamanoCuadro";
            CboCuadro.ValueMember = "idCuadro";
        }

        private void FrmGraduados_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarFoto();
            this.CargarAnillo();
            this.CargarCuadro();
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = NGraduado.Buscar(TxtBuscarNombre.Text);

                this.Formato();
                LblTotal.Text = "Total de registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Respuesta = "";
                if (TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Nombre");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un Nombre.");
                }

                else if (TxtInstituto.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar la Institución");
                    ErrorIcono.SetError(TxtInstituto, "Ingrese una Instutución.");
                }
                else if (TxtGrupo.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Grupo");
                    ErrorIcono.SetError(TxtGrupo, "Ingrese el Grupo");
                }
                else if (TxtTurno.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Turno");
                    ErrorIcono.SetError(TxtTurno, "Ingrese el Turno");
                }
                else if (TxtGeneracion.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar la Generación ");
                    ErrorIcono.SetError(TxtGeneracion, "Ingrese la Generación");
                }
                else
                {
                    Respuesta = NGraduado.Insertar(TxtNombre.Text.Trim(), TxtInstituto.Text.Trim(), TxtGrupo.Text.Trim(), TxtTurno.Text.Trim(),int.Parse(TxtGeneracion.Text), int.Parse(CboAnillo.SelectedValue.ToString()),int.Parse(CboCuadro.SelectedValue.ToString()),int.Parse(CboFoto.SelectedValue.ToString()),int.Parse(TxtAbono.Text));
                    if(Respuesta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de manera correcta");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            TabGeneral.SelectedIndex = 0;
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnAgregar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtInstituto.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Instituto"].Value);
                TxtGrupo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Grupo"].Value);
                TxtTurno.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Turno"].Value);
                TxtGeneracion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Generacion"].Value);
                TxtAbono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Abonos"].Value);
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione desde la celda Nombre");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                string Respuesta = "";
                if (TxtNombre.Text == string.Empty || TxtId.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Nombre");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un Nombre.");
                }

                else if (TxtInstituto.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar la Institución");
                    ErrorIcono.SetError(TxtInstituto, "Ingrese una Instutución.");
                }
                else if (TxtGrupo.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Grupo");
                    ErrorIcono.SetError(TxtGrupo, "Ingrese el Grupo");
                }
                else if (TxtTurno.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar el Turno");
                    ErrorIcono.SetError(TxtTurno, "Ingrese el Turno");
                }
                else if (TxtGeneracion.Text == string.Empty)
                {
                    this.MensajeError("Favor de ingresar la Generación ");
                    ErrorIcono.SetError(TxtGeneracion, "Ingrese la Generación");
                }
                else
                {
                    Respuesta = NGraduado.Actualizar(int.Parse(TxtId.Text), TxtNombre.Text.Trim(), TxtInstituto.Text.Trim(), TxtGrupo.Text.Trim(), TxtTurno.Text.Trim(), int.Parse(TxtGeneracion.Text), int.Parse(TxtAbono.Text));
                    if (Respuesta.Equals("OK"))
                    {
                        this.MensajeOk("Se Actualizó de manera correcta");
                        this.Limpiar();
                        this.Listar();
                        TabGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkSeleccionar.Checked)
            { 
               BtnEliminar.Visible = true;
            }
            else
            {
               BtnEliminar.Visible = false;
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           try
             {
               if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
              {                 
                 DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
              }

            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

            private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Esta seguro que deseas eliminar el registro?", "Graduaciones Del Noroeste",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Respuesta = "";
                    int a = 0;
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        a++;
                        if(DgvListado.SelectedRows.Count > 0 && a ==1)
                        {
                            Codigo = (Convert.ToInt32(DgvListado.CurrentRow.Cells[1].Value));
                            Respuesta = NGraduado.Eliminar(Codigo);

                            if(Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino el registro:" + Convert.ToString(row.Cells[2].Value));
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

