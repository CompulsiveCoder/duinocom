<%@ Page Language="C#" %>
<%@ Import Namespace="duinocom" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Send</title>
	<script runat="server">
	void Page_Load(object sender, EventArgs e)
	{
		var portName = Request.QueryString["p"];

		var message = Request.QueryString["m"];

		var communicator = getCommunicator(portName);

		Output(communicator.SendAndRead(message));
	}

	DuinoCommunicator getCommunicator(string portName)
	{
		DuinoCommunicator communicator = null;

		if (DuinoCommunicatorHolder.Communicator == null)
		{
			communicator = new DuinoCommunicator(portName);
			communicator.Open();
			DuinoCommunicatorHolder.Communicator = communicator;
		}
		else
		{
			communicator = DuinoCommunicatorHolder.Communicator;
		}

		return communicator;
	}

	void Output(string result)
	{
		OutputContainer.Controls.Add(new LiteralControl("<div>" + result.Replace(Environment.NewLine, "<br/>") + "</div>"));
	}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel runat="server" id="OutputContainer"/>
	</form>
</body>
</html>

