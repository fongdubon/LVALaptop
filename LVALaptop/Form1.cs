using LVALaptop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVALaptop
{
    public partial class frmEmpleados : MetroFramework.Forms.MetroForm
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                employeeBindingSource.DataSource =
                    dataContext.Employees.ToList();
            }
            pnlDatos.Enabled = false;
            Employee employee = employeeBindingSource.Current as Employee;
            if (employee != null && employee.ImageUrl != null)
                pctFoto.Image = Image.FromFile(employee.ImageUrl);
            else
                pctFoto.Image = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            pctFoto.Image = null;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            txtNombre.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=
                new OpenFileDialog() 
                {
                    Filter="archivos GIF|*.gif|archivos JPEG|*.jpg|archivos PNG|*.png|Todos los archivos|*.*"
                })
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    pctFoto.Image = Image.FromFile(ofd.FileName);
                    Employee employee = 
                        employeeBindingSource.Current as Employee;
                    if (employee != null)
                        employee.ImageUrl = ofd.FileName;

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtNombre.Focus();
            Employee employee =
                employeeBindingSource.Current as Employee;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MetroFramework.MetroMessageBox.Show(this,
                "¿Quieres eliminar el registro?",
                "Eliminar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question)==DialogResult.OK)
            {
                using (DataContext dataContext = new DataContext())
                {
                    Employee employee =
                        employeeBindingSource.Current as Employee;
                    if(employee!=null)
                    {
                        if (dataContext.Entry<Employee>(employee).State == EntityState.Detached)
                            dataContext.Set<Employee>().Attach(employee);
                        dataContext.Entry<Employee>(employee).State = EntityState.Deleted;
                        dataContext.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Empleado eliminado");
                        employeeBindingSource.RemoveCurrent();
                        pctFoto.Image = null;
                        pnlDatos.Enabled = false;
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = false;
            employeeBindingSource.ResetBindings(false);
            frmEmpleados_Load(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                Employee employee =
                    employeeBindingSource.Current as Employee;
                if (employee != null)
                {
                    if (dataContext.Entry<Employee>(employee).State == EntityState.Detached)
                        dataContext.Set<Employee>().Attach(employee);
                    if (employee.Id == 0)
                        dataContext.Entry<Employee>(employee).State = EntityState.Added;
                    else
                        dataContext.Entry<Employee>(employee).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Empleado guardado");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;
                }
            }
        }

        private void grdDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee employee = employeeBindingSource.Current as Employee;
            if (employee != null && employee.ImageUrl != null)
                pctFoto.Image = Image.FromFile(employee.ImageUrl);
            else
                pctFoto.Image = null;
        }
    }
}
