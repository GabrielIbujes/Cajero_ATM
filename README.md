# Cajero_ATM

ESCUELA POLITÉCNICA NACIONAL

ESCUELA DE FORMACIÓN DE TECNÓLOGOS

BDD 2

Integrantes: Jessica Amoguimba,
             Andrea Quishpe,
             Gabriel Ibujés.
             
             
Este está programa hecho en C# utilizando Visual Studio 2019, y Sql Server, modelo Cliente-Servidor,
es un sistema automatizado que permite a los clientes de entidades financieras realizar diferentes
tipos de acciones con su capital. Sin la necesidad de acudir a la entidad donde están registrados,
ni asistencia de alguna persona para realizar estas acciones. Facilita mucho el manejo de dinero en
caso de ser requerido.  

![Atm_readme](https://user-images.githubusercontent.com/49683647/72157064-007bc600-3385-11ea-9337-4016ba51ccff.png)

# Modelo Entidad-Relación:

Este modelo cuenta con tes tablas y sus atributos respectivos, la Tabla Usuario tiene relación con la Tabla Retiro y la Tabla Deposito ya
que un usuario puede realizar estas actividades. Su relación es de 1-n ya que un usuario puede realizar varios retiros o varios depósitos,
sin embargo, un deposito o un retiro solo puede tener un solo usuario ya que sus atributos serán únicos para cada usuario.

## Modelo Lógico:
![modelo-logico](https://user-images.githubusercontent.com/49683647/72158827-1a1f0c80-3389-11ea-8105-b1de32322392.jpeg)

## Modelo Conceptual:
![modelo-conceptual](https://user-images.githubusercontent.com/49683647/72158861-2c00af80-3389-11ea-9c2a-5a9d539132f1.jpeg)

