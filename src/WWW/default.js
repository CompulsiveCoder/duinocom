
	var xPosition = 90;
	var yPosition = 50;

	var minXPosition = 0;
	var maxXPosition = 180;
	var minYPosition = 10;
	var maxYPosition = 90;
	
	function send(sendUrl)
	{
		$.ajax({
		   url:sendUrl,
		   type:'GET',
		   success: function(data){
		       $('#outputContainer').html($(data).find('#OutputContainer').html());
		   }
		});
	}


	function checkYPosition(yPosition)
	{
	  if (yPosition < minYPosition)
	    yPosition = minYPosition;
	  else if (yPosition > maxYPosition)
	    yPosition = maxYPosition;

	  return yPosition;
	}

	function checkXPosition(xPosition)
	{
	  if (xPosition < minXPosition)
	    xPosition = minXPosition;
	  else if (xPosition > maxXPosition) 
	    xPosition = maxXPosition;

	  return xPosition;
	}

	$(document).ready(function(){
		$("#startCameraButton").click(function() {
  			$("#cameraContainer").html("<iframe src='http://j-pc:8090/test.swf' frameborder='0' style='width: 900px; height: 600px;' />");
		});

		$("#goButton").click(function() {
			$('#outputContainer').html("Loading.... (please wait)");

			var xPosition = $("#xPosition").val();
			var yPosition = $("#yPosition").val();
			var portName = $("#portName").val();
			var readCount = $("#readCount").val();

			var arguments = '?c=G&x=' + xPosition + '&y=' + yPosition + '&r=' + readCount + '&p=' + encodeURIComponent(portName);

			var sendUrl = "Send.aspx" + arguments;

			// Used for debugging
			//alert(sendUrl);

			send(sendUrl);

  			//$.get( sendUrl, function( data ) {
 			// $( ".result" ).html( data );
  				//alert( "Load was performed." );
			//});
		});

		$("#xDownButton").click(function() {
			var xPosition = $("#xPosition").val();
			if (xPosition > 0)
				xPosition--;
			$("#xPosition").val(xPosition);
		});

		$("#xUpButton").click(function() {
			var xPosition = $("#xPosition").val();
			if (xPosition < 180)
				xPosition++;
			$("#xPosition").val(xPosition);
		});

		$("#yDownButton").click(function() {
			var yPosition = $("#yPosition").val();
			if (yPosition > 0)
				yPosition--;
			$("#yPosition").val(yPosition);
		});

		$("#yUpButton").click(function() {
			var yPosition = $("#yPosition").val();
			if (yPosition < 90)
				yPosition++;
			$("#yPosition").val(yPosition);
		});

		$("#xResetButton").click(function() {
			$("#xPosition").val(90);
		});

		$("#yResetButton").click(function() {
			$("#yPosition").val(55);
		});

		$("#speedDownButton").click(function() {
			var speed = $("#speed").val();
			if (speed > 0)
				speed--;
			$("#speed").val(speed);
		});

		$("#speedUpButton").click(function() {
			var speed = $("#speed").val();
			if (speed < 90)
				speed++;
			$("#speed").val(speed);
		});

		$("#upButton").click(function() {
			var portName = $("#portName").val();
			var speed = $("#speed").val();

			var yPosition = $("#yPosition").val();
			if (parseInt(yPosition) > 0)
			{
				yPosition=parseInt(yPosition)-parseInt(speed);
				yPosition = checkYPosition(yPosition);
				$("#yPosition").val(yPosition);

				var sendUrl = "Send.aspx?c=u&s=" + speed + "&p=" + encodeURIComponent(portName);

			//alert(sendUrl);

				send(sendUrl);
			}

		});


		$("#downButton").click(function() {
			var portName = $("#portName").val();
			var speed = $("#speed").val();

			var yPosition = $("#yPosition").val();
			if (parseInt(yPosition) < 90)
			{
				yPosition=parseInt(yPosition)+parseInt(speed);
				yPosition = checkYPosition(yPosition);
				$("#yPosition").val(yPosition);

				var sendUrl = "Send.aspx?c=d&s=" + speed + "&p=" + encodeURIComponent(portName);

				//alert(sendUrl);

				send(sendUrl);
			}
		});


		$("#leftButton").click(function() {
			var portName = $("#portName").val();
			var speed = $("#speed").val();

			var xPosition = $("#xPosition").val();
			if (parseInt(xPosition) > 0)
			{
				xPosition=parseInt(xPosition)-parseInt(speed);
				xPosition = checkXPosition(xPosition);
				$("#xPosition").val(xPosition);

				var sendUrl = "Send.aspx?c=l&s=" + speed + "&p=" + encodeURIComponent(portName);

			//alert(sendUrl);

				send(sendUrl);
			}

		});


		$("#rightButton").click(function() {
			var portName = $("#portName").val();
			var speed = $("#speed").val();

			var xPosition = $("#xPosition").val();
			if (parseInt(xPosition) < 180)
			{
				xPosition=parseInt(xPosition)+parseInt(speed);
				xPosition = checkXPosition(xPosition);
				$("#xPosition").val(xPosition);

				var sendUrl = "Send.aspx?c=r&s=" + speed + "&p=" + encodeURIComponent(portName);

			//alert(sendUrl);

				send(sendUrl);
			}

		});

	});