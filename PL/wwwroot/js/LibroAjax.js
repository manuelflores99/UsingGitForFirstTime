$(document).ready(function () {

    GetAll();
});

function GetAll() {

    $.ajax({
        url: "https://localhost:7116/api/Libro/GetAll",
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (result) {
            console.log(result);
            if (result.success) {
                $.each(result.data, function (i, libro) {
                    $("#showLibros").append("<tr>" +
                        "<td><button type='button' class='btn btn-success' onclick='GetById(" + libro.idLibro + ")' >Editar</button></td>" +
                        "<td>" + libro.titulo + "</td>" +
                        "<td>" + libro.autor + "</td>" +
                        "<td>" + libro.iSBN + "</td>" +
                        "<td>" + libro.anioPublicacion + "</td>" +
                        "<td>" + libro.editorial.nombre + "</td>" +
                        "<td>" + libro.ciudad.nombreCiudad + "</td>" +
                        "<td><button type='button' class='btn btn-danger' onclick='Delete(" + libro.idLibro + ")'>Eliminar</button></td>" +
                        "</tr>"
                    );
                })
            }
        },
        error: function (error) {
            alert('Error en la conexion');
        }
    });
}

//function GetById(idLibro) {

//    $.ajax({
//        url: "https://localhost:7116/api/Libro/GetById" + id,
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        success: function (result) {
//            if (result.data) {
//                $("#ddlIdLibro").val(result.data.idLibro);
//                $("#ddlTitulo").val(result.data.titulo);
//                $("#ddlAutor").val(result.data.autor);
//                $("#ddlIsbn").val(result.data.iSBN);
//                $("#ddlAnio").val(result.data.anioPublicacion);

//                $($("#ddlEditorial")[0][0]).val(result.data.idEditorial);
//                $($("#ddlEditorial")[0][0]).text(result.data.nombreEditorial);

//                $($("#ddlCiudad")[0][0]).val(result.data.idCiudad);
//                $($("#ddlCiudad")[0][0]).text(result.data.nombreCiudad);

//                $("#btnUpd").show();
//                $("#btnAdd").hide();
//            }
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//    });
//}

//function Update() {
//    $.ajax({
//        url: "https://localhost:7116/api/Libro/Update",
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        contentType: 'application/json',
//        data: JSON.stringify({
//            idEmpledo: parseInt($("#ddlIdLibro").val()),
//            titulo: $("#ddlTitulo").val(),
//            autor: $("#ddlAutor").val(),
//            iSBN: $("#ddlIsbn").val(),
//            anioPublicacion: $("#ddlAnio").val(),
//            editorial: {
//                idEditorial: $("#ddlEditorial").val(),
//                ciudad: {
//                    idCiudad: $("#ddlCiudad").val()
//                }
//            }
//        }),
//        success: function (result) {
//            GetAll();
//            $("#btnExit").click();
//            alert("Registro Actualizado");
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//   });
//}



//function Add() {

//    $.ajax({
//        url: "https://localhost:7116/api/Libro/Add",
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        contentType: 'application/json',
//        data: JSON.stringify({

//            titulo: $("#ddlTitulo").val(),
//            autor: $("#ddlAutor").val(),
//            iSBN: $("#ddlIsbn").val(),
//            anioPublicacion: $("#ddlAnio").val(),
//            editorial: {
//                idEditorial: $("#ddlEditorial").val(),
//                ciudad: {
//                    idCiudad: $("#ddlCiudad").val()
//                }
//            }
//        }),
//        success: function (result) {
//            GetAll();
//            $("#btnExit").click(); //CloseModal
//            alert("Registro Agregado");
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//    });
//}


function Limpiar() {

    document.getElementById('ddlTitulo').value = ' ';
    document.getElementById('ddlAutor').value = ' ';
    document.getElementById('ddlIsbn').value = ' ';
    document.getElementById('ddlAnio').value = ' ';

    //GetAllEditoriales();
    //GetAllCiudades();

    $("#btnAdd").show();
    $("#btnUpd").hide();
}

//function Delete(idLibro) {

//    $.ajax({
//        url: "https://localhost:7116/api/Libro/Delete" + id,
//        type: "DELETE",
//        crossDomain: true,
//        dataType: "JSON",
//        success: function (result) {
//            alert("Registro Eliminado");
//        },
//        error: function (error) {
//            alert("No Hay Conexion");
//        }
//    });
//}


//function GetAllEditoriales() {

//    $("#ddlEditorial").empty();
//    $("#ddlEditorial").append("<option value = '0' >Selecciona una opcion</option>");
//    //$("#ddlEditorial").append("<option value = '0' >Selecciona una opcion</option>");

//    $.ajax({
//        url: "https://localhost:7116/api/Editorial/GetAll",
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        success: function (result) {
//            if (result.data) {
//                $.each(result.data, function (i, data) {
//                    $('#ddlEditorial').append('<option value =' + editoriales.data + '>' + data.nombreEditorial + '</option>');

//                })
//            }
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//    });
//}

//function GetAllCiudades() {

//    $("#ddlCiudad").empty();
//    $("#ddlCiudad").append("<option value = '0' >Selecciona una opcion</option>");
//    //$("#ddlEditorial").append("<option value = '0' >Selecciona una opcion</option>");

//    $.ajax({
//        url: "https://localhost:7116/api/Ciudad/GetAll",
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        success: function (result) {
//            if (result.data) {
//                $.each(result.data, function (i, data) {
//                    $('#ddlEditorial').append('<option value =' + data.idCiudad + '>' + data.nombreCiudad + '</option>');
//                })
//            }
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//    });
//} @onkeyup = "soloLetras(this, 'lblApellidoM')"

function ShowBtn() {
    $("#btnModal").click();
    $("#btnAdd").hide();
    $("#btnUpd").show();
}


function SoloLetras(input, label) {

    var teclas = $(input).val();
    var regex = /^[a-zA-Z\s]+$/;

    if (regex.test(teclas)) {

        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten letras");
        $(input).css({ "boder-color": "red", "background-color": "red" });

    }
    setTimeout(function () {

        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);
}


function LetrasYNumeros(input, label) {

    var teclas = $(input).val();
    var regex = /^[a-zA-Z0-9\s]*$/;

    if (regex.test(teclas)) {

        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten letras y numeros");
        $(input).css({ "boder-color": "red", "background-color": "red" });
    }

    setTimeout(function () {

        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);

}

function SoloNumeros(input, label) {

    var teclas = $(input).val();
    var regex = /^[0-9]+$/;

    if (regex.test(teclas)) {
        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten numeros");
        $(input).css({ "boder-color": "red", "background-color": "red" });
    }

    setTimeout(function () {
        $('#' + label).text("");
        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);

}

function ValidarCampos() {

    var titulo = document.getElementById('ddlTitulo').value.trim();
    var autor = document.getElementById('ddlAutor').value.trim();
    var isbn = document.getElementById('ddlIsbn').value.trim();
    var anio = document.getElementById('ddlAnio').value.trim();
    //var editorial = document.getElementById('ddlEditorial').value;
    //var ciudad = document.getElementById('ddlCiudad').value;

    // Verificar si algún campo está vacío
    if (titulo === "" || autor === "" || isbn === "" || anio === "" || editorial === "" || ciudad === "") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    return true;
}
