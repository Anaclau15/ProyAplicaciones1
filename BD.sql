-- Formulario 1
select nomAlumno + ' ' + apePaterAlumno as 'Nombre y apellido', ma.fecRegistro as 'Fecha reg.' from Tb_Matricula as ma
inner join Tb_Alumno as al on ma.codAlumno = al.codAlumno where year(ma.fecRegistro) = 2015;

-- Formulario 2
select codCurso, nomCurso from Tb_Curso;

select cur.codCurso, nomAlumno + ' ' + apePaterAlumno as 'Nombre y apellido', gr.nomGrado, ma.fecRegistro as 'Fecha reg.' from Tb_Matricula as ma
inner join Tb_Alumno as al on ma.codAlumno = al.codAlumno
inner join Tb_Seccion as sec on sec.codSeccion = ma.codSeccion
inner join Tb_Grado as gr on gr.codGrado = sec.codGrado
inner join Tb_Curso as cur on cur.codGrado = gr.codGrado
where cur.codCurso = 'CU0009';

select cur.nomCurso, count(al.codAlumno) 'Alumnos Registrados' from Tb_Matricula as ma
inner join Tb_Alumno as al on ma.codAlumno = al.codAlumno
inner join Tb_Seccion as sec on sec.codSeccion = ma.codSeccion
inner join Tb_Grado as gr on gr.codGrado = sec.codGrado
inner join Tb_Curso as cur on cur.codGrado = gr.codGrado
group by cur.nomCurso
