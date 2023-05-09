namespace MoogleEngine;
public class SnippetClass
{
    
    public static string  GetSnippet(int indexOfDoc, string[] Query)
    {
        
        int  max=0;
        double aux=0;
        string snippet="...";
        
        // Busca cual es la palabra mas importante d la query
        for (int i = 0; i < Query.Length; i++)
        {
            if(!Vocabulario.VectoresDocumento[indexOfDoc].Tfidef.ContainsKey(Query[i]))
                continue;

            double peso=Vocabulario.VectoresDocumento[indexOfDoc].Tfidef[Query[i]];  
            if(aux<peso)
            {
                aux=peso;
                max=i;
            }
                
        }

        
        string Document=File.ReadAllText(Vocabulario.paths[indexOfDoc]);
        int index=Document.ToLower().IndexOf(Query[max]);
        
        if(index<0)
            return snippet;
       
       
        else if(Document.Length-index <70)
            {
                snippet=snippet+Document.Substring(index,Document.Length-index)+ " ";
                
            }   
                

        else
            {
                snippet=snippet+Document.Substring(index,70);
            }        
                

            
        
        return snippet;
    }


}