$(document).ready(function () {

    var isAnimated = false;
    var temp;

    $('#TheB').click(function () {
        $.ajax({
            url: "http://localhost:49886/add/ToList",
            type: "POST",
            data: JSON.stringify({
                MyTitle: $('#myTitle').val(),
                Description: $('#TaskDescription').val()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $("#TestLabel").text(data.newlyAddedTask.ID);
                console.log(data);
                $('#ToDoList').append("<div class=\"ItemDiv\"><div class=\"DelButton\"/><div class=\"MoveButton\"/><li id=\"item\"><label class=\"HiddenID\">" + data.newlyAddedTask.ID + "</label>" + data.newlyAddedTask.Title + "</li></div>");
            }
        });

    });

    $(this).on('click', '.DelButton', function () {
        $.ajax({
            url: "http://localhost:49886/remove/FromList",
            type: "POST",
            data: JSON.stringify({
                ID: $(this).parent().find(".HiddenID").text()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function () {
                window.location.href = "/";
            }
        });
    });

    $(this).on('click', '#EditButton', function () {
        temp == $(".HiddenID").text;
        $.ajax({
            url: "http://localhost:49886/Edit/Task",
            type: "POST",
            data: JSON.stringify({
                MyTitle: $('#EditTitle').val(),
                Description: $('#EditTaskDescription').val(),
                ID: $('#HiddenCornerID').text()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (){
                window.location.href = "/";
            }
        });
    });

    $(this).on('click', '.MoveButton', function () {
        temp == $(".HiddenID").text;
        $.ajax({
            url: "http://localhost:49886/move/Item",
            type: "POST",
            data: JSON.stringify({
                ID: $(this).parent().find(".HiddenID").text()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                if (data.newlyAddedTask.isComplete)
                {
                    $('#DoneList').append("<div class=\"ItemDiv\"><div class=\"DelButton\"/><div class=\"MoveButton\"/><li id=\"item\"><label class=\"HiddenID\">" + data.newlyAddedTask.ID + "</label>" + data.newlyAddedTask.Title + "</li></div>");
                    window.location.href = "/";

                }
                else
                {
                    $('#ToDoList').append("<div class=\"ItemDiv\"><div class=\"DelButton\"/><div class=\"MoveButton\"/><li id=\"item\"><label class=\"HiddenID\">" + data.newlyAddedTask.ID + "</label>" + data.newlyAddedTask.Title + "</li></div>");
                    window.location.href = "/";
                }
            }
        });
    });

    $(this).on('click', '.ItemDiv', function () {

        $("#HiddenCornerID").text($(this).find(".HiddenID").text());

        
        $.ajax({
            url: "http://localhost:49886/Task/Info",
            type: "POST",
            data: JSON.stringify({
              ID: $("#HiddenCornerID").text()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $('#EditTitle').val(data.newlyAddedTask.Title);
                $('#EditTaskDescription').val(data.newlyAddedTask.Description);
                $('#HiddenCornerID').text(data.newlyAddedTask.ID);
            }
        });
    });
});



