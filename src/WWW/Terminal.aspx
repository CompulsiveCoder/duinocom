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

		portName = Request.QueryString["p"];
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

		.terminal
		{
			font-family: courier new;
			border: solid 1px black;
		}

		.output
		{
		}

		#outputContainer
		{
			background-color: lightgray;
		}
	</style>
</head>
<body>
	<script language="javascript" type="text/javascript" src="jquery-2.1.3.min.js"></script>
	<script language="javascript" type="text/javascript" src="terminal.js"></script>
	<form id="form1" runat="server">
	<h1>duinocom</h1>
	<div class="terminal">
	<div class="output">
	<div id="outputContainer"></div>
	</div>
	<div>
	Port: <input type="text" name="portName" id="portName" value='<%= portName %>'/> [If not automatically detected; ensure the arduino is connected via USB and hit refresh]
	</div>
	<div>
	Message: <input type="text" id="message"/><input type="button" value="Send" id="sendButton" />
	</div>
	</div>
	</form>
</body>
</html>

