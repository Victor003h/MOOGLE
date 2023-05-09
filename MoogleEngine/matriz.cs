namespace Matriz;
public class Matriz
{
    

    public static int[,] Suma (int[,] m1,int[,] m2)
    {
        if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
        {
            throw new Exception("No se puede sumar dos matrices con diferentes dimensiones");
        }
        for (int i = 0; i < m1.GetLength(0); i++)
            for (int j = 0; j < m1.GetLength(1); j++)
                m1[i, j] += m2[i, j];
    
    return m1;
    }
   
    public static int[,] Multiplicacion (int[,] m1,int[,] m2)
    {
        if (m1.GetLength(1)!=m2.GetLength(0)) throw new Exception ("Para multiplicar dos matrices la primera tiene que tener la misma cantidad de columnas como de filas la segunda  ");
        int[,] producto= new int[m1.GetLength(0),m2.GetLength(1)];
        for (int i =0;i<producto.GetLength(0);i++)
        {
            for(int j=0;j<producto.GetLength(1);j++)
            {
                for(int a=0;a<m1.GetLength(1);a++)
                {
                    producto[i,j]+=m1[i,a]*m2[a,j];
                }
            }
        }
        return producto;
    } 
    public static int[,] Resta (int[,] m1,int[,] m2)
    {
        if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
        {
            throw new Exception("no es posible restar dos matrices con diferentes dimensiones");
        }
        for (int i = 0; i < m1.GetLength(0); i++)
            for (int j = 0; j < m1.GetLength(1); j++)
                m1[i, j] -= m2[i, j];
        return m1;
    }


    public static int[,]ProdEscalar( int[,]a ,int k)
    {
        int[,] resul= new int[a.GetLength(0) , a.GetLength(1)];
         for (int i = 0; i < resul.GetLength(0); i++)
            for (int j = 0; j < resul.GetLength(1); j++)
                resul[i, j] = a[i, j]*k;        


        return resul;

    }
    public static int[,] Transpuesta(int[,] m1)
    {
        int[,] transpuesta= new int[m1.GetLength(1),m1.GetLength(0)];
        for (int i=0;i<transpuesta.GetLength(0);i++)
        {
            for(int j=0;j<transpuesta.GetLength(1);j++)
            {
                transpuesta[i,j]=m1[j,i];
            }
        }
    return transpuesta;
    }

}
