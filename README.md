# 📓 Práctica de Refactorización Guiada - Principios SOLID ✎ᝰ.

## 📝 Descripción de la Práctica a Realizar
Este proyecto contiene una serie de ejercicios de refactorización enfocados en la aplicación de los principios SOLID dentro de la Programación Orientada a Objetos (POO) utilizando C#.  
El objetivo principal es identificar problemas de diseño en diferentes fragmentos de código y aplicar mejoras que permitan obtener un software más mantenible, escalable y flexible.  

---

### 📚 Contenido de la práctica

La actividad a realizar está dividida en cinco partes, cada una enfocada en uno de los principios SOLID: En esta práctica fueron modificados unos bloques de código que no cumplian con los principios SOLID, con el onjetivo de refactorizarlos y lograr que estos cumplan con cada aspecto que conforma su nombre.

---

### 📕 Ejercicio No. 1 - Single Responsibility Principle (SRP) - Naomy Amador
---
**Problemática:** Esta clase tiene demasiadas responsabilidades porque: genera reportes, guarda archivos, envía correos, violando el principio de responsabilidad única. Ante esto, el estudiante tendrá que refactoriza el código separando responsabilidades en clases diferentes. Debe crear:  una clase para generar reportes, otra para guardar archivos, otra para enviar correos.
````csharp
//Ejercicio No. 1 - Código "malo" a modificar
public class Reporte
{
    public void GenerarReporte()
    {
        Console.WriteLine("Generando reporte...");
    }

    public void GuardarEnArchivo()
    {
        Console.WriteLine("Guardando archivo...");
    }

    public void EnviarPorCorreo()
    {
        Console.WriteLine("Enviando correo...");
    }
}
````
---

### Código refactorizado 📌
````csharp
//1era Clase - Función: Generar Reporte
public class GeneradorReporte
{
    public void GenerarReporte()
    {
        Console.WriteLine("Generando reporte...");
    }
}
//2da Clase - Función: Guardar Archivo
public class GestorArchivo
{
    public void GuardarEnArchivo()
    {
        Console.WriteLine("Guardando archivo...");
    }
}
//3era Clase - Función: Enviar Correo
public class ServicioCorreo
{
    public void EnviarPorCorreo()
    {
        Console.WriteLine("Enviando correo...");
    }
}
````
---
### 📑 Preguntas de análisis
---
#### ● ¿Qué problema tenía el diseño `original`?
El problema principal en este ejercicio era que la clase **Reporte** tenía varias responsabilidades al mismo tiempo. Además de generar reportes, también guardaba archivos y enviaba correos. Esto violaba el *Principio de Responsabilidad Única*, ya que una sola clase estaba encargándose de tareas diferentes.  

#### ● ¿Qué `ventajas` aporta la refactorización?
En lo general, la **refactorización** permite que cada clase tenga una función específica; de esta manera, esta metodología hace que el código sea más organizado, más fácil de entender y más sencillo de modificar o mantener cuando sea necesario realizar cambios.

#### ● ¿Qué ocurriría si el sistema `crece`?
En caso de que el sistema creciera demasiado, será mucho más fácil agregar nuevas funcionalidades sin afectar las demás clases. Por ejemplo, si se necesita cambiar la forma de enviar correos, solo habría que modificar la clase **ServicioCorreo**, sin tocar las clases encargadas de generar reportes o guardar archivos.  

---

### 📙 Ejercicio No. 2 - Open/Closed Principle (OCP) - Lía Torres

Se trabaja con un sistema de descuentos que requiere modificaciones constantes para agregar nuevos tipos de clientes. La refactorización busca extender funcionalidades sin modificar código existente.

---

### 📗 Ejercicio No. 3 - Liskov Substitution Principle (LSP) - Naomy Amador
**Problemática:** En esta clase el Pingüino rompe el comportamiento esperado de la clase base. Por ende, el estudiante tendrá que refactorizar el diseño para evitar que clases hijas tengan comportamientos inválidos. Debe realizarlo usando interfaces, clases más específicas y separación de comportamientos.

````csharp
//Ejercicio No. 3 - Código "malo" a modificar
public class Ave
{
    public virtual void Volar()
    {
        Console.WriteLine("Volando...");
    }
}

public class Pinguino : Ave
{
    public override void Volar()
    {
        throw new Exception("Los pingüinos no vuelan");
    }
}
````
---

### Código refactorizado 📌
````csharp
//Interfaz creada para la Actividad
public interface IVolador
{
    void Volar();
}
//Clase original (clase Madre)
public class Ave
{
    public void Comer()
    {
        Console.WriteLine("Comiendo...");
    }
}
//Clase hija No. 1 - Clase Ágila
public class Aguila : Ave, IVolador
{
    public void Volar()
    {
        Console.WriteLine("Volando...");
    }
}
//Clase hija No. 2 - Clase Pingüino
public class Pinguino : Ave
{
    public void Nadar()
    {
        Console.WriteLine("Nadando...");
    }
}
````
---
### 📑 Preguntas de análisis
---
#### ● ¿Por qué el pingüino viola `LSP`?
El pingüino **viola el Principio de Sustitución de Liskov** porque hereda de una clase que asume que todas las aves puedan volar. Sin embargo, los pingüinos no pueden hacerlo. Esto causa que la *clase hija* no pueda comportarse correctamente como la *clase madre* (clase original), generando un comportamiento incoherente dentro del programa.

#### ● ¿Qué `riesgos` genera esto?
Este problema puede provocar errores durante la ejecución del programa, porque si otra parte del sistema utiliza un objeto de tipo Ave esperando que pueda volar, el programa fallará al encontrarse con un pingüino. Además, el código se vuelve más difícil de mantener y agrandar porque no representa correctamente una realidad.

#### ● ¿Cómo mejorarías la `jerarquía`?
Esta puede mejorarse separando las aves que vuelan de las que no vuelan. Así, solo las clases que contienen la capacidad de volar tendrán el método **Volar()**. De esta forma, cada clase contiene únicamente los comportamientos que le corresponden y se evita obligar a una clase a realizar una acción que no puede hacer.

---

### 📒 Ejercicio No. 4 - Interface Segregation Principle (ISP) - Lía Torres

Se analiza una interfaz que obliga a implementar métodos innecesarios y se propone una división más específica de responsabilidades.

---

### 📘 Ejercicio No. 5 - Dependency Inversion Principle (DIP) - Naomy Amador
**Problemática:** En este caso en particular, la clase depende directamente de una implementación concreta **public class MySQLDatabase**. Debido a esto, el estudiante tendrá que Refactorizar usando interfaces, inyección de dependencias, abstracción; además, es importante que el sistema pueda de cambiar fácilmente la base de datos.

````csharp
//Ejercicio No. 5 - Código "malo" a modificar
public class MySQLDatabase
{
    public void Guardar()
    {
        Console.WriteLine("Guardando en MySQL");
    }
}

public class UsuarioService
{
    private MySQLDatabase db = new MySQLDatabase();

    public void CrearUsuario()
    {
        db.Guardar();
    }
}
````
---

### Código refactorizado 📌
````csharp
// Base para trabajar con cualquier base de datos
public interface IDatabase
{
    void Guardar();
}

// Base de datos MySQL
public class MySQLDatabase : IDatabase
{
    public void Guardar()
    {
        Console.WriteLine("Guardando en MySQL");
    }
}

public class UsuarioService
{
    // Variable para usar la base de datos
    private IDatabase db;

    // Recibe la base de datos que se va a usar
    public UsuarioService(IDatabase database)
    {
        db = database;
    }

    // Crea y guarda el usuario
    public void CrearUsuario()
    {
        db.Guardar();
    }
}
````
---
### 📑 Preguntas de análisis
---
#### ● ¿Por qué el acoplamiento es un `problema`?
El acoplamiento es un problema porque hace que una parte del programa dependa demasiado de otra. En este caso, UsuarioService solo podía trabajar con MySQL. Si más adelante se quisiera usar otra base de datos, habría que modificar el código, lo que implica más trabajo y aumenta la posibilidad de cometer errores.

#### ● ¿Qué `ventajas` ofrece depender de abstracciones?
La principal ventaja es que el programa se vuelve más flexible. En lugar de estar amarrado a una sola base de datos, puede trabajar con diferentes opciones sin tener que cambiar el código principal, facilitando de esa manera el realizar mejoras o cambios en el futuro.

#### ● ¿Cómo ayuda `DIP` en pruebas unitarias?
Esta cumple un papel fundamental gracias a que su ayuda permite probar una parte del programa sin necesitar todos los demás componentes funcionando. Por ejemplo, se puede comprobar si UsuarioService funciona correctamente sin conectarlo a una base de datos real. Esto hace que las pruebas sean más rápidas y sencillas.

---

## 🌐 Tecnologías utilizadas

- C#
- .NET
- Programación Orientada a Objetos (POO)
- Principios SOLID
- Visual Studio

---

## 📋 Objetivos de aprendizaje

- Comprender los principios SOLID.
- Detectar problemas de diseño en aplicaciones orientadas a objetos.
- Aplicar técnicas de refactorización.
- Mejorar la mantenibilidad y escalabilidad del código.
- Utilizar buenas prácticas de desarrollo de software.

---

## ✅ Principios trabajados

| Principio | Nombre | Objetivo |
|------------|---------|----------|
| S | Single Responsibility Principle | Una clase debe tener una sola responsabilidad |
| O | Open/Closed Principle | Abierto para extensión y cerrado para modificación |
| L | Liskov Substitution Principle | Las clases derivadas deben poder sustituir a sus clases base |
| I | Interface Segregation Principle | No obligar a implementar métodos innecesarios |
| D | Dependency Inversion Principle | Depender de abstracciones y no de implementaciones concretas |

---

## 💻 Ejecución

1. Clonar el repositorio.
2. Abrir la solución en Visual Studio.
3. Compilar el proyecto.
4. Ejecutar los ejemplos correspondientes a cada principio.
5. Analizar los resultados de la refactorización.

---

## 📜 Autoras 🪶

**Naomy Abigail Amador Encarnación Y Lía Karielys Torres Dominici**

---

## 💡 Conclusión

Esta práctica permite comprender cómo los principios SOLID contribuyen a la construcción de software más limpio, mantenible y adaptable a futuros cambios. A través de la refactorización de distintos ejemplos se evidencia la importancia de aplicar buenas prácticas de diseño para desarrollar aplicaciones más robustas y fáciles de mantener.