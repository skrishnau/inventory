var code = '1234-5678-9123-4567';
var reversed = code.replaceAll('-', '').split('').reverse().map((i)=>parseInt(i));
var revStr = ''; 
for(var i=0;i<reversed.length;i++) 
	revStr+= ((i== length-1) ? reversed[0] + reversed[i] : reversed[i]+reversed[i+1])*3%10;
