# My Project

## Versión en Español

Este repositorio contiene un proyecto de Unity construido con el MoreMountains TopDownEngine y paquetes relacionados.

### Instalación

1. **Clonar el repositorio**
   ```bash
   git clone <your-repo-url> "My project"
   cd "My project"
   ```

2. **Abrir con Unity**
   - Inicia Unity Hub.
   - Agrega la carpeta del proyecto (`My project`) al Hub si aún no está.
   - Abre el proyecto con la versión de Unity correspondiente (revisa `ProjectSettings/ProjectVersion.txt` para conocer la versión exacta).

3. **Restaurar paquetes**
   - Cuando Unity abra el proyecto, restaurará automáticamente los paquetes definidos en `Packages/manifest.json`.
   - Si se te solicita, permite que Unity importe y compile los assets.

4. **Configuración de compilación**
   - En Unity, ve a `File > Build Settings` y elige la plataforma de destino (p. ej., PC, Mac & Linux Standalone).
   - Agrega las escenas necesarias desde `Assets/Taller2/` u otras carpetas a la lista de compilación.

### Consejos y notas

- **Gestión de assets**: El proyecto utiliza una variedad de assets almacenados bajo `Assets/`. Asegúrate de no confirmar archivos grandes innecesarios; usa `.gitignore` para excluir `Library/`, `Temp/` y otras carpetas generadas.
- **Recursos de TopDownEngine**: Lee la documentación de MoreMountains para orientarte en el uso de funcionalidades del TopDownEngine como inventario, controladores de personajes y sistemas de cámara.
- **Scripts de editor**: Se incluyen varios proyectos `.Editor`; estos contienen inspectores personalizados y herramientas. En general deberían dejarse tal cual, a menos que planees extender la funcionalidad del editor.
- **Control de versiones**: Mantén `Packages/manifest.json` y la carpeta `ProjectSettings/` bajo control de versiones para mantener entornos consistentes entre colaboradores.

### URLs de assets

- **MoreMountains TopDownEngine**: https://assetstore.unity.com/packages/tools/game-toolkits/top-down-engine-148989
- **MoreMountains Inventory Engine**: https://assetstore.unity.com/packages/tools/game-toolkits/inventory-engine-164126
- **Universal Render Pipeline (URP)**: https://assetstore.unity.com/packages/essentials/starter-assets/universal-render-pipeline-215225

---

## English Version

This repository contains a Unity project built with the MoreMountains TopDownEngine and related packages.

## Installation

1. **Clone the repository**
   ```bash
   git clone <your-repo-url> "My project"
   cd "My project"
   ```

2. **Open with Unity**
   - Launch the Unity Hub
   - Add the project folder (`My project`) to the Hub if not already listed
   - Open the project with the appropriate Unity version (check `ProjectSettings/ProjectVersion.txt` for the exact version).

3. **Restore packages**
   - When Unity opens the project, it will automatically restore packages defined in `Packages/manifest.json`.
   - If prompted, allow Unity to import and compile assets.

4. **Build settings**
   - In Unity, go to `File > Build Settings` and choose the target platform (e.g., PC, Mac & Linux Standalone).
   - Add the required scenes from `Assets/Taller2/` or other folders into the build list.

## Tips & Notes

- **Asset Management**: The project uses a variety of assets stored under `Assets/`. Be sure not to commit unnecessary large files; use `.gitignore` to exclude `Library/`, `Temp/`, and other generated folders.
- **TopDownEngine Resources**: Read the MoreMountains documentation for guidance on using the TopDownEngine features such as inventory, character controllers, and camera systems.
- **Editor Scripts**: Several `.Editor` projects are included; these contain custom inspectors and tools. They should generally be left as-is unless you plan to extend editor functionality.
- **Version Control**: Keep the `Packages/manifest.json` and `ProjectSettings/` folder under version control to maintain consistent environments across collaborators.

## Asset URLs

- **MoreMountains TopDownEngine**: https://assetstore.unity.com/packages/tools/game-toolkits/top-down-engine-148989
- **MoreMountains Inventory Engine**: https://assetstore.unity.com/packages/tools/game-toolkits/inventory-engine-164126
- **Universal Render Pipeline (URP)**: https://assetstore.unity.com/packages/essentials/starter-assets/universal-render-pipeline-215225

Feel free to customize and expand this README with project-specific instructions or development notes.