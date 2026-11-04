# Sistema de Inventario

Aplicación de escritorio en C# (Windows Forms) para gestionar el inventario de productos de un negocio: registro, consulta, modificación, eliminación y control de existencias.

## Descripción

El sistema permite administrar productos con su nombre, categoría y proveedor, registrar entradas y salidas de existencias y consultar el stock disponible, con una alerta cuando este es bajo. La información se maneja únicamente en memoria mediante listas y colecciones (no se usa base de datos).

## Objetivo

Facilitar el control del inventario de un negocio mediante una aplicación sencilla, validada y organizada.

## Integrantes

| Nombre                  |  Usuario de GitHub |
|-------------------------|--------------------|
| Leonel Vaca Rojas       | 1e0ne101 |
| Monserat Aviles Ortiz   | avilesmonserat-eng  |
| Johan Jose Ortiz Delgado| ortizdelgadojohanjose04-ai|
| Johan Jimenez Moya      | UsuarioPendiente |
| Anais Rojas Caballero   | anaiselenarc-collab|

## Tecnologías

- C#
- Windows Forms
- .NET / Visual Studio
- Git y GitHub
- Markdown (documentación)

## Funcionalidades iniciales

> Mantener esta lista actualizada: solo incluir lo que realmente esté implementado.

- [ ] Registrar productos (nombre, categoría, proveedor)
- [ ] Mostrar productos en un DataGridView
- [ ] Actualizar existencias (entradas y salidas)
- [ ] Consultar productos por categoría o proveedor
- [ ] Modificar información de productos
- [ ] Eliminar productos
- [ ] Mostrar stock disponible y alertar cuando esté bajo

## Estado del proyecto

🚧 Avance 1 — en desarrollo.

## Estructura del proyecto

```
inventario-winforms/
├── README.md
├── src/
│   ├── Presentacion/   # Formularios, controles y eventos
│   ├── Logica/         # Validaciones y cálculos
│   └── Datos/          # Listas y colecciones en memoria
├── docs/
│   └── propuesta.md
└── evidencias/
    ├── avance-1/
    └── avance-2/
```

## Ejecución

1. Clonar el repositorio: `git clone https://github.com/1e0ne101/ProyectoFinal-inventario-winforms.git`
2. Abrir la solución (`.sln`) con Visual Studio.
3. Compilar (`Ctrl + Shift + B`) y ejecutar (`F5`).

## Convenciones del equipo

- Hacer `pull` antes de empezar a trabajar y `push` al terminar.
- Mensajes de commit descriptivos (ej. "Agregar validación de nombre de producto").
- Cada integrante trabaja en sus formularios o módulos asignados (ver `docs/propuesta.md`).
