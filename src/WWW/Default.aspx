<%@ Page Language="C#" %>
<%@ Import Namespace="duinocom" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
<head runat="server">
	<title>duinocom</title>
	<script runat="server">
	string portName = "";
	Dictionary<string, string> data;
	void Page_Load(object sender, EventArgs e)
	{
		var lister = new DuinoPortLister();

		data = lister.GetDictionary();
	}
	</script>
	<style>
		body
		{
			font-family: Verdana;
			font-size: 11px;
		}

		div
		{
			padding: 4px;
		}
	</style>
</head>
<body>
	<script language="javascript" type="text/javascript" src="jquery-2.1.3.min.js"></script>
	<script>

	$(document).ready(function(){

		$("#goButton").click(function() {
		});

	});
	</script>
	<form id="form1" runat="server">
	<div style="float:right">
	<div id="cameraContainer">Click "start camera"...</div>
	<input type="button" value="Start Camera" id="startCameraButton" />
	</div>
	<h1>duinocom</h1>
	<% foreach (var key in data.Keys){ %>
		<div><a href="Terminal.aspx?p=<%= key %>"><%= key %> - <%= data[key] %></a></div>
	<% } %>
	<% if (data.Count == 0){ %>
		<div>No duinos detected. Ensure your duino is connected and <a href='javascript:document.reload();'>refresh</a>.</div>
	<% } %>
	</form>
</body>
</html>

