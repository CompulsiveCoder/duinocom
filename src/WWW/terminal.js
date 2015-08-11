function send(sendUrl)
{
	$.ajax({
	   url:sendUrl,
	   type:'GET',
	   success: function(data){
	       $('#outputContainer').append($(data).find('#OutputContainer').html());
           $('#outputContainer').animate({scrollTop: $('#outputContainer').prop("scrollHeight")}, 500);
	   }
	});
}

function submit()
{
	var portName = $("#portName").val();
	var message = $("#message").val();

	var sendUrl = "Send.aspx?p=" + encodeURIComponent(portName) + "&m=" + message;

	//alert(sendUrl);

	send(sendUrl);

	$("#message").val("");
}

$(document).ready(function(){
	$("#sendButton").click(function() {
		submit();
	});
	$(document).keypress(function(e) {
	    if(e.which == 13) {
	    	submit();
	    }
	});
});