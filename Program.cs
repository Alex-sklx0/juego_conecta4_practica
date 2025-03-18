using System.Security.Cryptography.X509Certificates;

Tablero tablero1 = new Tablero();
tablero1.ComenzarOReiniciarPartida();
Jugadores jugador1 = new Jugadores();
Jugadores jugador2 = new Jugadores();
jugador1.SeleccionarColor();
jugador2.SeleccionarColor();

bool turno=true;
while(turno){
    
    if(tablero1.ValidarPosibleVictoria()=="rojo" && jugador1.Colorr=='r' || tablero1.ValidarPosibleVictoria()=="azul" && jugador1.Colorr=='a' ){
    jugador1.SumarVictoria();
    jugador2.SumarDerrota();
    turno=false;}
    else if(tablero1.ValidarPosibleVictoria()=="rojo" && jugador2.Colorr=='r' || tablero1.ValidarPosibleVictoria()=="azul" && jugador2.Colorr=='a' ){
    jugador2.SumarVictoria();
    jugador1.SumarDerrota();
    turno=false;
    }
    else{ 
        if(turno==false){
        tablero1.ComenzarOReiniciarPartida();
        jugador1.SeleccionarColor();
    jugador2.SeleccionarColor();
    turno=true;
    }
    
else{
jugador1.MarcarFicha();
jugador2.MarcarFicha();

}}}



public class Tablero{
    private static string [,] _tablero= new string [7, 8] ;
    
    public void ComenzarOReiniciarPartida(){
    GenerarTablero();
    ActualizarTablero();  
    }
    private void GenerarTablero(){
        for(int i = 0; i < _tablero.GetLength(0); i++){
            if(i==0){
                _tablero[i,0]="   ";
                }
            
            else {
                _tablero[i,0]=$" {Convert.ToString(i)} ";
            }

            for(int j = 1; j< _tablero.GetLength(1);j++){
                if(i==0){
                   
                _tablero[i,j]=$" {Convert.ToString(j)} ";
                }
                else {
                    _tablero[i,j]=" # ";
                }
            }
        }
    }
    public void ActualizarTablero(){
        for(int i = 0;i<_tablero.GetLength(0);i++){
            for(int j = 0; j< _tablero.GetLength(1);j++){
                if (_tablero[i, j] == " X ")
            {
                Console.ForegroundColor = ConsoleColor.Red; // Color rojo para "X"
            }
            else if (_tablero[i, j] == " O ")
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Color azul para "O"
            }
            else
            {
                Console.ResetColor(); // Restablecer el color predeterminado
            }
            Console.Write(_tablero[i, j]);
            }
        Console.WriteLine(); // Salto de línea después de cada fila
        }
    Console.ResetColor(); // Restablecer el color al final
    }
    public bool SePuedeColorearFicha(int ejey, int ejex, char color){
        bool coloreado;
    if (ejey >= 1 && ejey <= 6 && ejex >= 1 && ejex <= 7){
        if(color=='r' && _tablero[ejey,ejex]==" # "){
            
            _tablero[ejey,ejex]=" X ";
            
            System.Console.WriteLine("Ficha roja colocada");
            coloreado=true;

        }
        else
        if(color=='a' && _tablero[ejey,ejex]==" # "){
            _tablero[ejey,ejex]=" O ";
            System.Console.WriteLine("Ficha azul colocada");
            coloreado=true;
        }
        else{
         
            System.Console.WriteLine("No se puede marcar esta ficha");
            coloreado=false;            
        

        }}else{System.Console.WriteLine("No indique numeros fuera del rango de las calumnas y filas");
            coloreado=false;}
    return coloreado;
    
    }
public string ValidarPosibleVictoria(){
    string esVictoria;
     for(int i = 1;i<_tablero.GetLength(0);i++){
            for(int j = 1; j< 5;j++){
                if( _tablero[i,j]==" X " &&  _tablero[i,j+1]==" X " &&  _tablero[i,j+2]==" X " &&  _tablero[i,j+3]==" X " )
                { 
                esVictoria="rojo";
                System.Console.WriteLine("ganaste rojo");
                return esVictoria;
                }
                else if(_tablero[i,j]==" O " &&  _tablero[i,j+1]==" O " &&  _tablero[i,j+2]==" O " &&  _tablero[i,j+3]==" O " ){
                esVictoria="azul";
                System.Console.WriteLine("ganaste azul");
                return esVictoria;
                }
                
            }

        }
        for(int i = 1;i<_tablero.GetLength(1);i++){
            for(int j = 1; j< 4;j++){
        
        if( _tablero[j,i]==" X " &&  _tablero[j+1,i]==" X " &&  _tablero[j+2,i]==" X " &&  _tablero[j+3,i]==" X ")
                { 
                esVictoria="rojo";
                System.Console.WriteLine("ganaste rojo");
                return esVictoria;

                }
                else if( _tablero[j,i]==" O " &&  _tablero[j+1,i]==" O " &&  _tablero[j+2,i]==" O " &&  _tablero[j+3,i]==" O "){
                esVictoria="azul";
                System.Console.WriteLine("ganaste azul"); 
                return esVictoria;

                }
 
                
                }}
        for(int i = 4;i<_tablero.GetLength(0);i++){
            for(int j = 1; j< 5;j++){
        
        if( _tablero[i,j]==" X " &&   _tablero[i-1,j+1]==" X " &&  _tablero[i-2,j+2]==" X " && _tablero[i-3,j+3]==" X ")
                {
                esVictoria="rojo";
                System.Console.WriteLine("ganaste rojo");
                return esVictoria;
                }
                else if( _tablero[i,j]==" O " &&   _tablero[i-1,j+1]==" O " &&  _tablero[i-2,j+2]==" O " && _tablero[i-3,j+3]==" O "){
                esVictoria="azul";
                System.Console.WriteLine("ganaste azul"); 
                return esVictoria;
                }
                
                }}
         for(int i = 4;i<_tablero.GetLength(0);i++){
            for(int j = 7; j> 3;j--){
        
        if( _tablero[i,j]==" X " &&   _tablero[i-1,j-1]==" X " &&  _tablero[i-2,j-2]==" X " && _tablero[i-3,j-3]==" X ")
                { 
                esVictoria="rojo";
                System.Console.WriteLine("ganaste rojo");
                return esVictoria;
                }
                else if( _tablero[i,j]==" X " &&   _tablero[i-1,j-1]==" X " &&  _tablero[i-2,j-2]==" X " && _tablero[i-3,j-3]==" X "){
                esVictoria="azul";
                System.Console.WriteLine("ganaste azul");
                return esVictoria;
                }
                }}
        return esVictoria="";
}
}
interface IJugadores{
    void ResetearContadores();
    void SumarVictoria();
    void SumarDerrota();
    void MarcarFicha();
    // void Reseleccionarcolores();

}
public class Jugadores: Colores, IJugadores{
   private char _color;
   private int _victorias;
   private int _derrotas;
   public int Victorias{
    get{return _victorias;}
    set{_victorias=value;}
   }
   public int Derrotas{
    get{return _derrotas;}
    set{_derrotas=value;}
   }
   public char Colorr{get{return _color;}set{_color=value;}}
   public Jugadores(){
    Derrotas=_derrotas;
    Victorias=_victorias;
   }
   public void ResetearContadores(){
    _victorias=0;
    _derrotas=0;
    System.Console.WriteLine("Contadores reseteados");
   }
   public void SumarVictoria(){
    _victorias+=1;
   }
    public void SumarDerrota(){
    _derrotas+=1;
   }
   public char SeleccionarColor(){
    Colorr=Color();
    return Colorr;
   }
   public void MarcarFicha(){
    Tablero tablerito = new Tablero();
    System.Console.WriteLine("Ingrese el valor del eje Y que desea marcar");
    int ejey= Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine("Ingrese el valor del eje X que desea marcar");
    int ejex= Convert.ToInt32(Console.ReadLine());
    if(tablerito.SePuedeColorearFicha(ejey, ejex, Colorr))
    tablerito.ActualizarTablero();
    else MarcarFicha();
    }
    
      
}

public class Colores{
    private static bool _colorRojo;
    private static bool _colorAzul;
    protected bool colorRojo{
        get{return _colorRojo;}
        set{_colorRojo=value;}
    }
    protected bool colorAzul{
        get{return _colorAzul;}
        set {_colorAzul=value;}
    }

    public char Color(){
         char seleccionado='v';//vacio
        System.Console.WriteLine("Seleccione un color: rojo o azul");
        
        string color= Console.ReadLine();
        switch(color){
            case "rojo": 
            if(ColorEstaSeleccionado(color)==false){
            colorRojo=true;
            seleccionado= 'r';
            } else  {System.Console.WriteLine("No seleccione el mismo color de su adversario");Color();}

            break;
            case "azul": 
            if(ColorEstaSeleccionado(color)==false){
            colorAzul=true;
            seleccionado= 'a';
            } else  {System.Console.WriteLine("No seleccione el mismo color de su adversario"); Color();}
            ; break;
            default: System.Console.WriteLine("no seleccione otra opcion que no sea 'r' o 'a'"); Color(); break;
        }
        return seleccionado;
    }
    public bool ColorEstaSeleccionado(string color){
        bool yaFueSeleccionado;
        if(color=="rojo" && colorRojo || color=="azul" && colorAzul){
            yaFueSeleccionado=true;
        }else{
            yaFueSeleccionado=false;
        }
    return yaFueSeleccionado;
    }
}