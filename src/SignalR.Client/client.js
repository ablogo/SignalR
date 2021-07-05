var d = new Date();
var userId = "u" + d.getSeconds() + d.getMilliseconds();

document.addEventListener("DOMContentLoaded", () => {
    // <snippet_Connection>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44386/chathub", 
        {
            accessTokenFactory: () =>
            {
                return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic2lnbmFsci11c2VyMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImNvcnJlb0BnbWFpbC5jb20iLCJpc3MiOiJodHRwOi8vand0LmlvIiwianRpIjoiMDEiLCJpYXQiOjE2MTk2NDI3MDAsImV4cCI6MTY1ODc1NTIwMH0.jbZ7Ek91luNXKIf6pjtR_HXZhU6wQ3H7pgny_9MTHlU";
            }
        })
        .configureLogging(signalR.LogLevel.Error)
        .build();
    // </snippet_Connection>

    // <snippet_ReceiveMessage>
    connection.on("ReceiveMessage", (user, message) => {
        printMessageReceived(user, message);
    });

    connection.on("ReceiveMessageFromGroup", (group, message) => {
        printMessageReceived(group, message);
    });
    // </snippet_ReceiveMessage>

    document.getElementById("sendButton").addEventListener("click", async () => {
        
        //const user = document.getElementById("user").value;
        const message = document.getElementById("message");

        // <snippet_Invoke>
        try {
            await connection.invoke("SendMessageToGroup", userId, message.value);
            printMessage(userId, message.value);
            message.value = "";
        } catch (err) {
            console.error(err);
        }
        // </snippet_Invoke>
    });

    setUser();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };

    connection.onclose(start);

    // Start the connection.
    start();
});

function setUser()
{
    document.querySelector("#user-id span").innerText = userId;
}

function printMessage(user, message)
{
    const p = document.createElement("p");
    p.classList.add("text-end");
    p.textContent = `${user}: ${message}`;
    document.getElementById("message-list").appendChild(p);
}

function printMessageReceived(user, message)
{
    const p = document.createElement("p");
    p.classList.add("text-start");
    p.textContent = `${user}: ${message}`;
    document.getElementById("message-list").appendChild(p);
}