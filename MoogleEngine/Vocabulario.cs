namespace MoogleEngine;

    public class Vocabulario
    {
       
       
         // Aqui guardamos las direcciones de cada documentos
        public static string[] paths= Directory.GetFiles("..//Content","*.txt");
       
        // aqui se guarda cada documento en una lista
        public static  List<string>[] WordOFDoc=new List<string>[paths.Length];

        // Almacenamos cada palabra con su  objeto tipo WordInfo
        public static Dictionary<string,WordInfo> Vocabulary = new Dictionary<string, WordInfo>();

       
        // Un array con los vectores de los documentos
        public static Document[] VectoresDocumento= new Document[paths.Length];
        public static int cantOfDoc=paths.Length;
       


        // metodo para separar en palabras un el contenido d un documento
        public static string[] ConvertToWord(string path) 
        {
            string text=File.ReadAllText(path);
            string texto=text.ToLower();
            string[] palabras=texto.Split();
            List<string> lis=new List<string>();
           
            string aux;
            for (int i = 0; i < palabras.Length; i++)
            {
                aux=Token(palabras[i]).ToLower();
                if(!string.IsNullOrWhiteSpace(aux))
                {
                    aux.ToLower();
                    lis.Add(aux);
                }      
                   
            }
           
            return lis.ToArray();
        }
        
        // Metodo para eliminar todo aquello que no sea una letra o digito en la palabra
        public static string Token(string word )
        {  
            int len=word.Length;
            int cont=0;
            string resul=word;
            for (int i = 0; i <resul.Length; i++)
            {
    
                if(i==resul.Length-1-cont&& !char.IsLetterOrDigit(resul[i]))
                {
                     resul=resul.Remove(i);
                     cont++;
                }
                else if(!char.IsLetterOrDigit(resul[i]))
                {         
                    resul=resul.Remove(i,1); 
                    cont++;      
                }
            }
            return resul;
        }
        
        
        
        public static void Insert()
        {    
            for (int i = 0; i < paths.Length; i++)
            {
               
               string[] aux=ConvertToWord(paths[i]);
               WordOFDoc[i]=aux.ToList();            
            }
         
        }
        // Metodo para insertar las palabras en el vocabulario
        public static void InsertWords()
        {  
           Insert();
            for (int j = 0; j < WordOFDoc.Length; j++)
            {
                for (int i = 0; i <WordOFDoc[j].Count; i++)
                {
                    string word=WordOFDoc[j][i].ToLower();
                    if(String.IsNullOrWhiteSpace(word))   continue;
                    // comprobamos si esta la palabra
                    if(!Vocabulario.Vocabulary.ContainsKey(word))
                    {
                        // crea un objeto WordInfo
                        Dictionary<int,double> Tf=new Dictionary<int, double>();
                        Tf.Add(j,1);
                        WordInfo w1=new WordInfo(Tf,1);
                        Vocabulario.Vocabulary.Add(word,w1);
                    
                    }

                    else
                    {     // si la palabra ya habia aparecido antes en el documento se le adiciona una ocurrencia
                        if(Vocabulary[word].Tf.ContainsKey(j))
                        {
                            
                            Vocabulary[word].Tf[j]++;
                        }
                        else
                            {   // sino guardamos el indice del documento en su respectivo objeto WordINFO
                                Vocabulary[word].Tf.Add(j,1);
                                Vocabulary[word].NumOfDoc++;
                            }
                    }
                }
            }
           
        }
        
        // Metodo para crear los vectores documentos
        public static void InsertDoc()
        {
            for (int i = 0; i < WordOFDoc.Length; i++)
            {
                Dictionary<string,double> v1= new Dictionary<string, double>();
                string title=Path.GetFileName(Vocabulario.paths[i]);
                for (int j = 0; j < WordOFDoc[i].Count; j++)
                {    
                    
                    string w=WordOFDoc[i][j];
                    if(v1.ContainsKey(w))   continue;
                    double tf=Vocabulary[w].Tf[i]/(double)WordOFDoc[i].Count;
                    double idf=Math.Log10((cantOfDoc+1)/Vocabulary[w].NumOfDoc);
                    double Tfidef=tf*idf;
                    v1.Add(w,Tfidef);
                }
                VectoresDocumento[i]= new Document(title,v1);
            }
            
        }



        
    }


