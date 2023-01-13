using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
	public class ChatController : Controller
	{
		private static ICollection<KeyValuePair<string, string>> Messages =
			new List<KeyValuePair<string, string>>();

		public IActionResult Show()
		{
			var chatHistory = new ChatViewModel();

			if (!Messages.Any())
			{
				return View(chatHistory);
			}

			chatHistory.Messages = Messages
				.Select(m => new MessageViewModel
				{
					Sender = m.Key,
					MessageText = m.Value
				})
				.ToList();

			return View(chatHistory);
		}

		[HttpPost]
		public IActionResult Send(ChatViewModel model)
		{
			Messages.Add(new KeyValuePair<string, string>(
				model.CurrentMessage.Sender,
				model.CurrentMessage.MessageText));

			return RedirectToAction("Show");
		}
	}
}
