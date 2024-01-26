# The Plan

## Architecture

**Stoneshard Mod** (TCP Client) <=> **C# Console Application** (TCP Server + WebSocket Client) <=> **Twitch PubSub API** (WebSocket Server)

---

### C# console application
- WebSocket Client : Subscribe to Events on Twitch PubSub API.
- TCP Server : When an event is received by the WebSocket Client, the TCP Server sends a command to Stoneshard.

---

### Stoneshard Mod
- Custom TCP Client (PubSub): Listens to C# server for commands, executes proper GML scripts.
- TwitchIO TCP Client (Twitch API): Listens to Twitch API server for chat messages.
- Scripts : The GML Scripts to be run when the proper command from the C# Server is received.

---

### Twitch PubSub API
- Sends Events (Channel points redeems, subs...) over WebSocket connection.
- C# Server receives them and sends proper commands to Stoneshard.
