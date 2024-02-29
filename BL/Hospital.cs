using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BL
{
    public class Hospital
    {

        public static Dictionary<string,object> Add(ML.Hospital hospital)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Hospital", null } };
            try
            {
                using (DL.KpalomaresCrud1Context context = new DL.KpalomaresCrud1Context())
                {
                    var registro = context.Database.ExecuteSqlRaw($"HospitalAdd'{hospital.Nombre}','{hospital.Direccion}',@AñoConstruccion,{hospital.Capacidad},{hospital.especialidad.IdEspecialidad}", new SqlParameter ( "@AñoConstruccion", hospital.AñoConstruccion ));

                    if (registro < 0 )
                    {

                        resultado["Resultado"] = true;
                        resultado["Hospital"] = hospital;

                    }

                }
            }
            catch (Exception ex)
            {
                resultado["Resultado"] = true;
                resultado["Excepcion"] = ex.Message;
            }
            return resultado;
        }
        public static Dictionary<string,object> Delete(int IdHospital)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Hospital", null } };
            try
            {
                using (DL.KpalomaresCrud1Context context = new DL.KpalomaresCrud1Context())
                {
                    var registro = context.Database.ExecuteSqlRaw($"HospitalDelete {IdHospital}");
                    if (registro < 0)
                    {
                        resultado["Resultado"] = true;
                        
                    }

                
                }

            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;
            }
            return resultado;
        }

        public static Dictionary<string,object> GetAll()
        {
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", "" }, { "Hospital", null } };
            try
            {
                using (DL.KpalomaresCrud1Context context = new DL.KpalomaresCrud1Context())
                {
                    var registros = (from Hospital in context.Hospitals
                                     select new
                                     {
                                         IdHospital = Hospital.IdHospital,
                                         Nombre=Hospital.Nombre,
                                         Direccion=Hospital.Direccion,
                                         Capacidad=Hospital.Capacidad,
                                         AñoConstruccion=Hospital.AñoConstruccion,
                                         IdEspecialidad=Hospital.IdEspecialidad

                                     }).ToList();

                    if (registros.Count > 0)
                    { 
                    
                    
                    
                    
                    }
                
                
                
                }

            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;
            }


            return resultado;
        }






    }
}
