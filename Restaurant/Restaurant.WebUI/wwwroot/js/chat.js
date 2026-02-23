var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7500/signalrhub")
    .build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var now = new Date();
    var timeString = now.getHours().toString().padStart(2, '0') + ":" +
        now.getMinutes().toString().padStart(2, '0');

    // Chat penceresi ve yeni mesaj baloncuðu
    var messageList = document.getElementById("messageList");
    var div = document.createElement("div");

    // Tasarým sýnýfýný belirle (Senin CSS'indeki .sent ve .received sýnýflarý)
    // Not: Buradaki 'user' ismi giriþ yapanla ayný mý kontrolü için basit bir mantýk:
    var currentUser = document.getElementById("userInput").value;
    var isMe = (user === currentUser);

    div.className = "message-bubble " + (isMe ? "sent" : "received");

    div.innerHTML = `<strong>${user}</strong>: ${message} <span class="message-info">${timeString}</span>`;

    messageList.appendChild(div);

    // Otomatik aþaðý kaydýr
    var chatWindow = document.getElementById("chatWindow");
    chatWindow.scrollTop = chatWindow.scrollHeight;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error("Baðlantý Hatasý: " + err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;

    if (message) {
        // DÝKKAT: Sadece message gönderiyoruz, user'ý hub kendisi bulacak
        connection.invoke("SendMessage", message).catch(function (err) {
            return console.error(err.toString());
        });
        document.getElementById("messageInput").value = "";
    }
    event.preventDefault();
});