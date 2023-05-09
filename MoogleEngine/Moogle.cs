namespace MoogleEngine;


public static class Moogle
{

    public static SearchResult Query(string query) 
    {
       
        //Comprobamos si existe algun documento
        if(Vocabulario.paths.Length==0) return (new SearchResult(new SearchItem[0] ));
        if(Vocabulario.Vocabulary.Count==0) return (new SearchResult(new SearchItem[0] ));
        //Procesamos la query
        string[] wordOfQuery=query.Split();
        List<string> lis=new List<string>();
           
        string aux;
        for (int i = 0; i < wordOfQuery.Length; i++)
        {
            aux=Vocabulario.Token(wordOfQuery[i]).ToLower();
            if(!string.IsNullOrWhiteSpace(aux))
            {
                aux.ToLower();
                lis.Add(aux);
            }      
                   
        }
        wordOfQuery=lis.ToArray();
       
        //Coprobamos si alguna palabra no aprece en el diccionario y la cambiamos por la mas similar. 
        bool suggestion=false; 
        for (int i = 0; i < wordOfQuery.Length; i++)
        {
           if(!Vocabulario.Vocabulary.ContainsKey(wordOfQuery[i]))
           {
                suggestion=true;
                wordOfQuery[i]=SearchResult.Suggestions(wordOfQuery[i]);
                
           }
        }
        
        //Creamos el vector query.
        Dictionary<string,double> vectorQuery=new Dictionary<string, double>();
        double t=wordOfQuery.Length;
        for (int i = 0; i < wordOfQuery.Length; i++)
        {     
           string word=wordOfQuery[i];
           if(!vectorQuery.ContainsKey(word))
           {
                vectorQuery.Add(word,(double)1/t);
           }           
            else
                vectorQuery[word]+=(double)1/t;
               
        }    

        //Calculamos su idf
        foreach (var element in vectorQuery)
            {
                string key=element.Key;
                double idf=Math.Log10((Vocabulario.cantOfDoc+1)/Vocabulario.Vocabulary[key].NumOfDoc);
                vectorQuery[key]*=idf;                         
            }



        string Query=string.Join(' ',wordOfQuery);
        Document QueryDoc= new Document(Query,vectorQuery);
        
        //luego procedemos a calcular la similitud entre los vectores y la query
        SearchItem[] items = SearchItem.Sim(Vocabulario.VectoresDocumento,QueryDoc);
        SearchItem.Sort(items);
        
        //coprobamos la sugerencia
        if(suggestion) 
        {
            return new SearchResult(items, Query);
        }     
        else 
        {
           
            return new SearchResult(items);
        }

            
    }

}



