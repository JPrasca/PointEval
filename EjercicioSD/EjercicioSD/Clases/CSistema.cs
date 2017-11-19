using System;

namespace EjercicioSD.Clases
{
    class CSistema
    {
        #region atributos
        CPunto puntoCritico;
        #endregion

        #region constructores
        public CSistema(double[,] sistemaIn)
        {
            puntoCritico = new CPunto(sistemaIn);
        }

        public CSistema()
        {
            int a = 0;
        }
        #endregion
        
        #region Métodos de evaluación

        public bool SoloHayUnPunto()
        {
            if (((puntoCritico.Valores[0, 0] * puntoCritico.Valores[1, 1]) - puntoCritico.Valores[1, 0] * puntoCritico.Valores[0, 1]) != 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public string EvaluarTipo()
        {
            try
            {
                return puntoCritico.Tipo;
            }
            catch (Exception ex)
            {
                return "No se puede obtener tipo" + ex.Message;
            }
        }

        public string EvaluarEstabilidad()
        {
            try
            {
                return puntoCritico.Estabilidad;
            }
            catch (Exception ex)
            {
                return "No se puede obtener estabilidad" + ex.Message;
            }
        }

        public string MostrarRaicesYDatos()
        {
            try
            {
                return "\n-(a1 + b2) = " + -puntoCritico.A1B2 + 
                       "\nDet(A) = " + puntoCritico.DetA +  
                       "\nm1 = " + puntoCritico.Raices[0] + 
                       "\nm2 = " + puntoCritico.Raices[1];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }


}
