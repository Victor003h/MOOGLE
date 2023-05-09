namespace MoogleEngine;

public class SearchItem
{
    public SearchItem(string title, string snippet, double score)
    {
        this.Title = title;
        this.Snippet = snippet;
        this.Score = score;
    }
    public string Title { get; private set; }

    public string Snippet { get; private set; }

    public double Score { get; private set; }


    // Metodo para la creacion de un SearchItem con su score a traves de la simultud coseno
    public static SearchItem SimCos(Document d1, Document Query)
    {
        int index=0;
        string title=d1.title;
        double score=0;
    
        if(Document.Norma(Query)!=0 && Document.Norma(d1)!=0)    
            score= Document.ProdEscalar(d1,Query)/(Document.Norma(d1)*Document.Norma(Query));
        
        for (int i = 0; i < Vocabulario.VectoresDocumento.Length; i++)
        {
            if(d1==Vocabulario.VectoresDocumento[i])
                index=i;
        }

        string snippet=SnippetClass.GetSnippet(index,Query.title.Split());
        SearchItem doc=new SearchItem(title, snippet, score);
        return doc;
    }

    //Metodo para crear un array d SearchItem con todos los Documentos 
    public static SearchItem[] Sim(Document[] Vectores, Document query)
    {
       
        
        List<SearchItem> Resultlist=new List<SearchItem>();
        for (int i = 0; i < Vectores.Length; i++)
        {
            
            SearchItem item=SearchItem.SimCos(Vectores[i], query);
            if(item.Score==0) continue;
            Resultlist.Add(item);
        }

        SearchItem[] Result=Resultlist.ToArray();
        return Result;

    }


     //Ordena el array de SearchItem d mayor a menor score
    public static void Sort(SearchItem[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Intercambiar(a ,i, PosMayor(a,i));
        }
    }
     
   //Intercambia de posicion 2 valores de array 
    private static void Intercambiar(SearchItem[] a, int i, int j)
    {
        SearchItem aux=a[j];
        a[j]=a[i];
        a[i]=aux;
    }   

    // Da la posicion del SearchItem con mayor score a partir d cierto indice
    private static int PosMayor(SearchItem[] a, int s)
    {
        int p=s;
        for (int i = s+1; i < a.Length; i++)
        {
            if(a[p].Score <a[i].Score)
                p=i;
        }
        return p;
    }   


}
