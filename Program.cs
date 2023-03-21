using System.Collections.Generic;

Dictionary<string, int> dicCursos = new Dictionary<string, int>();
int seleccionMenu;
int promedioRecaudado;
int recaudacionTotal = 0;
string seleccionRepetir;
string cursoMayor;

do {
    seleccionMenu = IngresarEntero("1. Ingrese los importes del curso   2. Ver estadisticas");
    switch(seleccionMenu){
        case 1:
            CalcularRecaudacion();
        break;
        case 2:
            if(dicCursos.Count > 0){
                cursoMayor = CalcularCursoMayor();
                Console.WriteLine($"El curso que mas plata recaudo fue: {cursoMayor}");
                promedioRecaudado = recaudacionTotal / dicCursos.Count;
                Console.WriteLine($"El promedio recaudado en total es de: ${promedioRecaudado}");
                Console.WriteLine($"La recaudacion total fue de: ${recaudacionTotal}");
                Console.WriteLine($"La cantidad de cursos es: {dicCursos.Count}");
            }
            else {
                Console.WriteLine("No se han ingresado datos aun.");
            }

        break;
        default:
            Console.WriteLine("Error, seleccion incorrecta");
        break;
    }
    seleccionRepetir = IngresarTxt("Queres regresar al menu? [si/no]");
}while(seleccionRepetir == "si");
string CalcularCursoMayor(){
    int mayor = 0;
    string cursoMayor = "";
    foreach(string clave in dicCursos.Keys){
        if(dicCursos[clave] > mayor){
            mayor = dicCursos[clave];
            cursoMayor = clave;
        }
    }
    return cursoMayor;
}

void CalcularRecaudacion(){
    string curso;
    int alumnos;
    int recaudacionIndividual;
    recaudacionTotal = 0;

    curso = IngresarTxt("Ingrese el curso");
    alumnos = IngresarEntero("Ingrese el numero de alumnos");
    for(int i = 0; i < alumnos; i++){
        
        recaudacionIndividual = IngresarEnteroPositivo("Ponga cuanta plata ingreso el alumno");
        recaudacionTotal = recaudacionTotal + recaudacionIndividual;
    }
    dicCursos.Add(curso, recaudacionTotal);

}
int IngresarEntero(string mensaje){
    int n;
    Console.WriteLine(mensaje);
    n = int.Parse(Console.ReadLine());
    return n;
}
int IngresarEnteroPositivo(string mensaje)
{
    int n;
    do{
        Console.WriteLine(mensaje);
        n = int.Parse(Console.ReadLine());
    }while(n <= 0);
    return n;
}
string IngresarTxt(string mensaje){
	string txt;
	Console.WriteLine(mensaje);
	txt = Console.ReadLine();
	return txt;
}