# Sistema de Inventario

Aplicación de escritorio en C# (Windows Forms) para gestionar el inventario de productos de un negocio: registro, consulta, modificación, eliminación y control de existencias.

## Descripción

El sistema permite administrar productos con su nombre, categoría y proveedor, registrar entradas y salidas de existencias y consultar el stock disponible, con una alerta cuando este es bajo. La información se maneja únicamente en memoria mediante listas y colecciones (no se usa base de datos).

## Objetivo

Facilitar el control del inventario de un negocio mediante una aplicación sencilla, validada y organizada.

## Integrantes

| Nombre                   | Usuario de GitHub          |
|--------------------------|----------------------------|
| Leonel Vaca Rojas        | 1e0ne101                   |
| Monserat Aviles Ortiz    | avilesmonserat-eng         |
| Johan Jose Ortiz Delgado | ortizdelgadojohanjose04-ai |
| Johan Jimenez Moya       | UsuarioPendiente           |
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
| Lista compartida de productos en memoria (`Inventario`) | 🚧 |
| Mostrar stock disponible y alertar cuando esté bajo | 🚧 |
| Registrar productos (nombre, categoría, proveedor) | 🚧 |
| Mostrar productos en un DataGridView / consultar por categoría o proveedor | 🚧 |
| Actualizar existencias (entradas y salidas) | ⬜ |
| Modificar información de productos | ⬜ |
| Eliminar productos | ⬜ |

## Estado del proyecto

🚧 Avance 2 — en desarrollo.

## Estructura del proyecto

```
ProyectoFinal-inventario-winforms/
├── README.md
├── ProyectoFinal-inventario-winforms.slnx
└── SistemaInventario/
    ├── Producto.cs
    ├── FormulariosProductos.cs
    └── SistemaInventario/
        ├── FormPrincipal.cs        # Pantalla principal
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
