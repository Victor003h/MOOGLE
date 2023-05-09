namespace MoogleEngine;

public class Distance
{

    public static double LevenshteinDistances(string x, string y)
    {
        int f=x.Length;
        int c=y.Length;
        int peso=0;

        if(f==0 || c==0)
            return 0;

        //Se llenan la primera fila y la primera columna
        int[,] m= new int[f+1,c+1];
        for (int i = 0; i <=f; i++)
            m[i,0]=i;
            
        for (int i = 0; i <=c; i++)
            m[0,i]=i;

        // Se llena el resto d la matriz
        for (int i = 1; i <=f; i++)
        {
            for (int j = 1; j <=c; j++)
            {
                if(x[i-1]==y[j-1])
                    peso=0;
                else
                peso=1;
                m[i,j]=Math.Min(Math.Min(m[i-1,j]+1,m[i,j-1])+1,m[i-1,j-1]+peso);
            }
        }

        // se Calcula el porcentaje d diferencia
        double porcentaje=0;
        if(x.Length>y.Length)
            porcentaje=(m[f,c])/ (double) x.Length;

        else 
            porcentaje=(m[f,c])/ (double) y.Length;

        return porcentaje;    
    }

}










