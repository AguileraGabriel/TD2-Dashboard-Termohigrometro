# Dashboard de Visualización de Datos LPC 845

Esta aplicación desarrollada en C# es un dashboard diseñado para mostrar de forma gráfica los datos obtenidos por el LPC 845. Si bien puede que no sea ideal para entornos de campo, resulta muy útil en el taller, donde permite visualizar de forma detallada el comportamiento del equipo acondicionador en reparación.

---

## Características

- **Visualización Gráfica:**
  - **Gráficos de Línea:**  
    - Valor de temperatura medido por los termistores.  
    - Valores de referencia proporcionados por el sensor SHT30 (temperatura, humedad y punto de rocío).
  - **Gráfico de Tacómetro:**  
    - Ofrece una visualización rápida del estado del salto térmico, indicando numéricamente el valor y utilizando un código de colores para señalar si se encuentra dentro de los intervalos esperables.

- **Enfoque en el Diagnóstico:**  
  - Ideal para el análisis y diagnóstico en el taller, facilitando la identificación de posibles fallas en equipos acondicionadores de aire.

---

## Requisitos

- **Plataforma:**  
  - .NET Framework o .NET Core (según la versión utilizada en el desarrollo).

- **Hardware:**  
  - LPC 845 para la adquisición de datos.
  - Sensores asociados (termistores y sensor SHT30).

---

## Instalación

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/tu_usuario/tu_repositorio.git
