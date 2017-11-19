using System;

namespace EjercicioSD.Clases
{
    class CPunto
    {

        #region atributos
        private int valorDePrueba;
        private double[,] valores;  //matríz de coeficientes del sistema
        private double a1b2, detA;
        private string tipo, estabilidad;
        private string[] raices = { "", "" };
        #endregion


        #region constructores
        public CPunto(double[,] valoresIn)
        {
            Valores = valoresIn;

        }

        #endregion

        #region Propiedades (Getters/Setters)
        public double[,] Valores
        {
            get
            {
                return valores;
            }

            set
            {
                valores = value;
            }
        }

        public string Tipo
        {
            get
            {
                //Asignación de valores a los coeficientes del polinomio característico
                double a = 1,
                       b = -(valores[0, 0] + valores[1, 1]),
                       c = ((valores[0, 0] * valores[1, 1]) - valores[1, 0] * valores[0, 1]),
                       m1 = 0,
                       m2 = 0;


                //Si es o no complejo
                if (Math.Sqrt((b * b) - (4 * a * c)) >= 0)
                {
                    //raíces del polinomio
                    m1 = ((-b) / (2 * a)) + Math.Sqrt((b * b) - (4 * a * c)) / (2 * a);
                    m2 = ((-b) / (2 * a)) - Math.Sqrt((b * b) - (4 * a * c)) / (2 * a);

                    //determinación del tipo (Si ambas raíces tienen el mismo signo es nodo, si no es silla)
                    if ((m1 * m2) > 0 || (m1 == m2))
                    {
                        tipo = "Nodo";
                    }
                    else
                    {
                        tipo = "Silla";
                    }

                    //Llenado de cadenas para mostrar raíces
                    raices[0] = Math.Round(m1, 4).ToString();
                    raices[1] = Math.Round(m2, 4).ToString();
                }
                else
                {

                    //Con las raíces complejas, se verifica si son o no puras para determinar si es espiral o centro
                    if (((-b) / (2 * a)) != 0)
                    {
                        tipo = "Espiral";
                    }
                    else
                    {
                        tipo = "Centro";
                    }


                    //llenado de cadenas para mostrar raíces (Parte real)
                    raices[0] = (((-b) / (2 * a)) != 0) ? Math.Round(((-b) / (2 * a)), 4).ToString() : "";
                    raices[1] = (((-b) / (2 * a)) != 0) ? Math.Round(((-b) / (2 * a)), 4).ToString() : "";

                    //concatenación de cadenas para mostrar raíces (Parte imaginaria)
                    raices[0] += " + " + Math.Round((Math.Sqrt(-((b * b) - (4 * a * c))) / (2 * a)), 4).ToString() + " i ";
                    raices[1] += " - " + Math.Round((Math.Sqrt(-((b * b) - (4 * a * c))) / (2 * a)), 4).ToString() + " i ";

                }

                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Estabilidad
        {
            get
            {
                //Asignación de valores a los coeficientes del polinomio característico
                double a = 1,
                       b = -(valores[0, 0] + valores[1, 1]),
                       c = ((valores[0, 0] * valores[1, 1]) - valores[1, 0] * valores[0, 1]),
                       m1 = 0,
                       m2 = 0;

                //Si es o no complejo
                if (Math.Sqrt((b * b) - (4 * a * c)) >= 0)
                {
                    //raíces del polinomio
                    m1 = ((-b) / (2 * a)) + Math.Sqrt((b * b) - (4 * a * c)) / (2 * a);
                    m2 = ((-b) / (2 * a)) - Math.Sqrt((b * b) - (4 * a * c)) / (2 * a);

                    //determinación de la estabilidad
                    if (m1 < 0 && m2 < 0)
                    {
                        //si ambas raíces tienen parte real negativa es sólo estable
                        estabilidad = "Asintóticamente Estable";
                    }
                    else if (m1 <= 0 && m2 <= 0)
                    {

                        //si ambas raíces tienen parte real no positiva entonces estable
                        estabilidad = "Estable";
                    }
                    else
                    {
                        //si no cumple ninguna de las anteriores entonces no tiene estabilidad
                        estabilidad = "Inestable";
                    }

                }
                else
                {
                    //si tiene raíces complejas

                    //si son imaginarias 
                    if (((-b) / (2 * a)) < 0)
                    {
                        //si ambas raíces tienen parte real negativa entonces es asitóticamente estable
                        estabilidad = "Asintóticamente Estable";
                    }
                    else if (((-b) / (2 * a)) <= 0)
                    {

                        //si ambas raíces tienen parte real no positiva es sólo estable
                        estabilidad = "Estable";
                    }
                    else
                    {
                        //si no cumple ninguna de las condiciones entonces no tiene estabilidad
                        estabilidad = "Inestable";
                    }
                }

                //si -(a1+b2) y det(A) son positivos entonces es asintóticamente estable
                estabilidad = (b > 0 && c > 0) ? "Asintóticamente estable" : estabilidad;
                return estabilidad;
            }

            set
            {
                estabilidad = value;
            }
        }

        public string[] Raices
        {
            get
            {
                return raices;
            }
        }

        public double A1B2
        {
            get
            {
                a1b2 = (valores[0, 0] + valores[1, 1]);
                return a1b2;
            }

        }

        public double DetA
        {
            get
            {
                detA = ((valores[0, 0] * valores[1, 1]) - valores[1, 0] * valores[0, 1]);
                return detA;
            }
        }

        #endregion
    }
}
