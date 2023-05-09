namespace MoogleEngine;
public  class Document
{
        // Cada palabra con su respectivo TFIDF
        public Dictionary<string,double> Tfidef =new Dictionary<string, double>();
        // Titulo del documento
        public string title;
      
    

    public Document (string title,Dictionary<string,double> Tfidef )
    {
        this.Tfidef=Tfidef;
        this.title=title;
        
    }


    public static double ProdEscalar(Document d1, Document query)
    {   
        double Result=0;
        for (int i = 0; i <  query.Tfidef.Count; i++)
        {
            string word=query.Tfidef.ElementAt(i).Key;
            if(d1.Tfidef.ContainsKey(word))
            {
                Result+=d1.Tfidef[word] * query.Tfidef[word];
            }
        }
        return Result;
    }


    public static double Norma(Document d1)
    {
        double[] doc=d1.Tfidef.Values.ToArray();

        double result=0;
        for (int i = 0; i < doc.Length; i++)
        {
            result+=Math.Pow( doc[i],2);
        }
        result=Math.Sqrt(result);

        return result;
    }
                
}