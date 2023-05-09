namespace MoogleEngine;

public class SearchResult
{
    private SearchItem[] items;

    public SearchResult(SearchItem[] items, string suggestion="")
    {
        if (items == null) {
            throw new ArgumentNullException("items");
        }

        this.items = items;
        this.Suggestion = suggestion;
    }
    
    public SearchResult() : this(new SearchItem[0]) {

    }

    
    public string Suggestion { get; private set; }

    public IEnumerable<SearchItem> Items() {
        return this.items;
    }

    public int Count { get { return this.items.Length; } }


    // Retorna la palabra con mayor similitud al parametro
    public static string Suggestions(string word)
    {
        
        double distancia=1;
        string parecida=word;
       
        for (int i = 0; i < Vocabulario.Vocabulary.Count; i++)
        {
            
            string palabra=Vocabulario.Vocabulary.ElementAt(i).Key;
            double x=Distance.LevenshteinDistances(word,palabra);
            if(x<distancia)
            {
                parecida=palabra;
                distancia=x;
            }
                    
            else if(distancia<0.27)  
            {    
                return parecida;
            }
    
        }    
            
         return parecida;
    }

    

}
