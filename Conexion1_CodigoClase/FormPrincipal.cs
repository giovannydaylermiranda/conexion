using System;                    // Console, EventArgs
using System.Data;               // DataTable, CommandType, SqlDbType
using System.Windows.Forms;      // Form
using Microsoft.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataReader, SqlException

namespace Conexion1_CodigoClase
{
    // Código del formulario. Esta clase es IGUAL en los 5 proyectos:
    // lo único que cambia entre ellos es la clase Conexion (archivo Conexion.cs).
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();   // Crea los controles definidos en FormPrincipal.Designer.cs
        }

        

        // =====================================================================
        // BOTÓN 2 · LISTAR CLIENTES (consulta básica)
        // Aquí la conexión se cierra SOLA gracias a "using".
        // =====================================================================
        private void BtnListar_Click(object sender, EventArgs e)
        {
            // La consulta SQL que queremos ejecutar, escrita como texto.
            string sql = "SELECT id_cliente, nombres, apellidos, telefono, email " +
                         "FROM dbo.clientes " +
                         "WHERE activo = 1 " +
                         "ORDER BY apellidos, nombres;";

            try
            {
                // using: al salir de las llaves se cierra la conexión automáticamente,
                // aunque ocurra un error. Equivale al try/finally con Close() del botón 1.
                using (SqlConnection conexion = Conexion.Crear())
                using (SqlCommand comando = new SqlCommand(sql, conexion))   // Une la consulta con la conexión
                {
                    conexion.Open();                                         // Abre la conexión

                    using (SqlDataReader lector = comando.ExecuteReader())   // Ejecuta el SELECT y obtiene las filas
                    {
                        DataTable tabla = new DataTable();   // Tabla en memoria para guardar el resultado
                        tabla.Load(lector);                  // Copia todas las filas del lector a la tabla

                        dgvDatos.DataSource = tabla;         // Muestra la tabla en la grilla
                        lblEstado.Text = $"{tabla.Rows.Count} clientes activos.";
                        Console.WriteLine($"Consulta ejecutada: {tabla.Rows.Count} filas.");
                    }
                }   // <- aquí "using" cierra el lector, el comando y la conexión
                Console.WriteLine("Conexión cerrada automáticamente por using.");
            }
            catch (SqlException ex)
            {
                lblEstado.Text = $"Error {ex.Number}: {ex.Message}";
                Console.WriteLine($"ERROR {ex.Number}: {ex.Message}");
            }
        }

        // =====================================================================
        // BOTÓN 3 · BUSCAR CON PROCEDIMIENTO ALMACENADO
        // Llama a dbo.sp_buscar_clientes (crearlo antes con el script sp_buscar_clientes.sql).
        // =====================================================================
        private void BtnBuscarSP_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();   // Lo que el usuario escribió, sin espacios al inicio/final

            try
            {
                using (SqlConnection conexion = Conexion.Crear())
                // En vez de una consulta, el comando lleva el NOMBRE del procedimiento.
                using (SqlCommand comando = new SqlCommand("dbo.sp_buscar_clientes", conexion))
                {
                    // Indica que el texto anterior es un procedimiento almacenado, no un SELECT.
                    comando.CommandType = CommandType.StoredProcedure;

                    // Envía el parámetro @texto (NVARCHAR(50)) con el valor escrito en el formulario.
                    comando.Parameters.Add("@texto", SqlDbType.NVarChar, 50).Value = texto;

                    conexion.Open();                                          // Abre la conexión

                    using (SqlDataReader lector = comando.ExecuteReader())    // Ejecuta el procedimiento
                    {
                        DataTable tabla = new DataTable();
                        tabla.Load(lector);                                    // Guarda el resultado
                        dgvDatos.DataSource = tabla;                           // Lo muestra en la grilla

                        // Mensaje en la CONSOLA: cuántos clientes encontró y cuáles son.
                        Console.WriteLine($"sp_buscar_clientes('{texto}') encontró {tabla.Rows.Count} cliente(s):");
                        foreach (DataRow fila in tabla.Rows)                   // Recorre fila por fila
                        {
                            Console.WriteLine($"  {fila["id_cliente"]} - {fila["nombres"]} {fila["apellidos"]}");
                        }
                        lblEstado.Text = $"El procedimiento encontró {tabla.Rows.Count} cliente(s) con '{texto}'.";
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 2812 = el procedimiento no existe (falta ejecutar el script en SQL Server).
                string ayuda = ex.Number == 2812 ? " ¿Ejecutaste el script sp_buscar_clientes.sql?" : "";
                lblEstado.Text = $"Error {ex.Number}: {ex.Message}{ayuda}";
                Console.WriteLine($"ERROR {ex.Number}: {ex.Message}{ayuda}");
            }
        }
    }
}
