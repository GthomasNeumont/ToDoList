$(document).ready(function () {

    var isAnimated = false;

    $('#TheB').click(function () {
        var O =
            {
                myTitle: $('#myTitle').val(),
                description: $('#TaskDescription').val()
            };


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
                $('#ToDoList').detach($(this).parent());
                $('#ToDoList').remove($(this).parent());
                $(this).find('.ItemDiv').detach();
            }
        });
    });

    $(this).on('click', '.ItemDiv', function () {
        /*$.ajax({
            url: "http://localhost:49886/remove/FromList",
            type: "POST",
            data: JSON.stringify({
                ID: $(this).parent().find(".HiddenID").text()
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function () {
                $('#ToDoList').detach($(this).parent());
                $('#ToDoList').remove($(this).parent());
                $(this).find('.ItemDiv').detach();
            }
        });*/
        $("#ToDoListDiv").animate({
            'marginLeft' : "-=300px"
        });
        isAnimated = true;
    });
});



