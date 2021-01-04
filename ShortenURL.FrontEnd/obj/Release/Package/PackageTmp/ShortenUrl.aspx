<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortenUrl.aspx.cs" Inherits="ShortenURLFrontEnd.ShortenUrl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <div class="form-group row">
                <div class="col-sm-2">
                    <label>Enter the URL to Shorten</label>
                </div>
                <div class="col-sm-4">
                    <textarea id="PlainURL" name="PlainURL" rows="4" cols="50"></textarea>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-2">
                </div>
                <div class="col-sm-4">
                    <input class="btn btn-primary" type="button" value="Convert" id="ConvertToURL" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    <label>Shortened URL</label>
                </div>
                <div class="col-sm-4">
                    <span id="waitLoading" style="display: none;">Please wait....</span>
                    <a href="#" target="_blank" style="font-weight: bolder; background-color: aquamarine;" id="DisplayShorternURL"></a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>


<script type="text/javascript">
    $("#ConvertToURL").click(function () {
        debugger;
        var PlainUrl = $("#PlainURL").val();

        if (PlainUrl == "") {
            alert("Please enter the URL");
            return;
        }
        var shortenurl = '<%=ConfigurationManager.AppSettings["shortenurl"]%>';
        var shortenApi = '<%=ConfigurationManager.AppSettings["shortenApi"]%>';        
        if ((shortenApi != null && shortenApi != '' && shortenApi != undefined) && (shortenurl != null && shortenurl != '' && shortenurl != undefined)) {
            $("#waitLoading").css("display", "block");
            if (validURL(PlainUrl)) {
                var EndPoint = shortenApi + PlainUrl;
                $.ajax({
                    url: EndPoint,
                    contentType: "application/json",
                    crossDomain: true,
                    type: "GET",
                    dataType: 'json',
                    success: function (result) {
                        $("#DisplayShorternURL").text(shortenurl + result);
                        $("#DisplayShorternURL").attr("href", PlainUrl);
                        $("#waitLoading").css("display", "none");
                    }
                });
            }
            else {
                $("#DisplayShorternURL").text('');
                $("#waitLoading").css("display", "none");
                alert("Please enter the valid url");
            }
        }
        else {
            alert("Please check the configuration settings");
        }

    });

    function validURL(str) {
        var pattern = new RegExp('^(https?:\\/\\/)?' + // protocol
            '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|' + // domain name
            '((\\d{1,3}\\.){3}\\d{1,3}))' + // OR ip (v4) address
            '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + // port and path
            '(\\?[;&a-z\\d%_.~+=-]*)?' + // query string
            '(\\#[-a-z\\d_]*)?$', 'i'); // fragment locator
        return !!pattern.test(str);
    }
</script>
