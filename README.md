# Sistema de Inventario

Aplicación de escritorio en C# (Windows Forms) para gestionar el inventario de productos de un negocio: registro, consulta, modificación, eliminación y control de existencias.

## Descripción

El sistema permite administrar productos con su nombre, categoría, proveedor, precio y cantidad, registrar entradas y salidas de existencias y consultar el stock disponible, con una alerta cuando este es bajo. La información se maneja únicamente en memoria mediante listas y colecciones (no se usa base de datos), por lo que los datos se pierden al cerrar el programa.

## Objetivo

Facilitar el control del inventario de un negocio mediante una aplicación sencilla, validada y organizada.

## Integrantes

| Nombre                   | Usuario de GitHub          |
|--------------------------|----------------------------|
| Leonel Vaca Rojas        | 1e0ne101                   |
| Monserat Aviles Ortiz    | avilesmonserat-eng         |
| Johan Jose Ortiz Delgado | ortizdelgadojohanjose04-ai |
| Johan Jimenez Moya       | jogerin77-dev              |
| Anais Rojas Caballero    | anaiselenarc-collab        |

## Tecnologías

- C#
- Windows Forms
- .NET / Visual Studio
- Git y GitHub
- Markdown (documentación)

## Estado de las funcionalidades

Leyenda: ✅ terminado · 🚧 en desarrollo o en revisión · ⬜ pendiente

| Funcionalidad | Estado |
|---------------|--------|
| Pantalla principal (navegación, resumen y salida con confirmación) | ✅ |
| Validaciones de datos (campos vacíos, números positivos) | ✅ |
| Lista compartida de productos en memoria (`Inventario`) | ✅ |
| Mostrar stock disponible y alertar cuando esté bajo | ✅ |
| Registrar productos (nombre, categoría, proveedor, precio y cantidad) | ✅ |
| Consultar productos en un DataGridView con búsqueda por nombre | ✅ |
| Actualizar existencias (entradas y salidas) | ✅ |
| Modificar información de productos | ✅ |
| Eliminar productos | ✅ |

## Estado del proyecto

✅ Avance 2 — todas las funcionalidades principales están implementadas y probadas.

## Uso del programa

1. **Registrar Productos:** se ingresan nombre, categoría, proveedor, precio y cantidad. El código (Id) se asigna automáticamente y los datos se validan antes de guardarse.
2. **Consultar Productos:** muestra todos los productos en una tabla y permite buscar por nombre.
3. **Modificar / Existencias:** al seleccionar un producto de la tabla se puede modificar su información, eliminarlo (con confirmación) o registrar entradas y salidas de existencias. Una salida no puede superar el stock disponible.
4. **Pantalla principal:** muestra el total de productos, las unidades en stock y la lista de productos con stock bajo (5 unidades o menos).

## Estructura del proyecto

```
ProyectoInventario.Final/
├── README.md
├── ProyectoFinal-inventario-winforms.slnx
└── SistemaInventario/
    ├── Producto.cs
    ├── FormulariosProductos.cs     # versión inicial en consola (no incluida en el proyecto)
    └── SistemaInventario/
        ├── FormPrincipal.cs        # Pantalla principal
        ├── FrmRegistro.cs          # Registro de productos
        ├── Form1ConsultaBusqueda.cs # Consulta y búsqueda
        ├── FrmGestion.cs           # Modificar, eliminar y existencias
        ├── Program.cs
        ├── Datos/                  # Lista compartida en memoria (Inventario)
        └── Logica/                 # Validaciones y cálculos
```

## Ejecución

1. Clonar el repositorio: `git clone https://github.com/1e0ne101/ProyectoInventario.Final.git`
2. Abrir `SistemaInventario/SistemaInventario.slnx` con Visual Studio.
3. Compilar (`Ctrl + Shift + B`) y ejecutar (`F5`).

## Convenciones del equipo

- La rama `main` está protegida: todo cambio entra mediante un Pull Request con al menos 1 aprobación de otro integrante.
- Cada integrante trabaja en su propia rama y hace `pull` antes de empezar.
- Mensajes de commit descriptivos (ej. "Agregar validación de nombre de producto").
- Cada integrante trabaja en sus formularios o módulos asignados.