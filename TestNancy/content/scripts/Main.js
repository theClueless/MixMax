/*

         Main.Js

*/

$(document).ready(function() {

    "use strict";

    function diplayResults(lists) {
        var resDiv = $("#resultsdiv");

        resDiv.empty();
        
        $.each(lists, function(i, item) {
            console.log("got return value: " + item);
            var result = "<div class='result'>" +
                                "<div class='title'>" + item.name + "</div>" +
                                "<div>Songs: " + item.songCount + "</div>" +
                                "<button id='download'>Download" + "</button>" +
                        "</div>";
            console.log(result);
            resDiv.append(result);
            if (i === 1) {
                $("#download").on("click", function() {
                    console.log("button is: " + item.name);
                    window.open("getPlaylist/" + item.name, '_blank', '');
                    // $.get("getPlaylist/" + item.name);
                });
            }
        });
    }


    $.get("generatePlaylist")
        .success(function (r)
        {
            diplayResults(r);
        }
        );

    
    var testMsg = "this is a message for the console";
    console.log(testMsg);
    //var resDiv = document.getElementById("resultsdiv");
    //var html = "<ul>";
    //html += "<li>All Files</li>";

    //var res = [
    //    {
    //        name: "one",
    //        val: 10
    //    },
    //    {
    //        name: "two",
    //        val: -5
    //    }
    //];
    //for (var i = 0; i < res.length; i++) {
    //    html += "<li>name:" + res[i].name + ", Value: " + res[i].val + "</li>";
    //}
    //html += "</ul>";
    //resDiv.innerHTML = html;

})