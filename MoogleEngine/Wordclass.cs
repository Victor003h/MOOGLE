namespace MoogleEngine;
public class WordInfo
{

    //Aqui guardamos la cantidad  de veces que aparece la palabra en cada documento
    public Dictionary<int,double> Tf =new Dictionary<int, double>();

    //numero de documento donde aparece la palabra
    public  double NumOfDoc; 

    public WordInfo(Dictionary<int,double> Tf, double NumOfDoc)
    {

        this.Tf=Tf;
        this.NumOfDoc=NumOfDoc;

    }


   


}