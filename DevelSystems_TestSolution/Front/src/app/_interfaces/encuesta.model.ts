export interface EncuestaModel {
  nombre: string;
  descripcion: string;
  link: string;
  opciones: { clave: string, valor: string }[];
}
