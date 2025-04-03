using System;

namespace OOP
{
    // Родительский класс
    public class Conversation
    {
        public virtual void Speak()
        {
            Console.WriteLine("Say hello!");
        }
    }
    
    // Класс-потомок
    public class PhoneConversation : Conversation
    {
    }

    // Класс-потомок
    public class VideoConversation : Conversation
    {
        public override void Speak()
        {
            Console.WriteLine("Wave a hand in camera");
        }
    }

    // Класс-контейнер, который демонстрирует свойство ковариантности в C#
    public class Covariance
    {
        private Conversation _conversation;

        public Covariance(Conversation conversation)
        {
            _conversation = conversation;
        }

        public void CallParentMethod()
        {
            _conversation.Speak();
        }
    }

    public class Example
    {
        // Определеяется генерик делегат ConversationsTrigger, который с помощью ключевого слова in позволяет применить 
        // контрвариантность при его реализации
        private delegate void ConversationsTrigger<in T>(T conversation);

        public void Main()
        {
            // В качестве аргумента конструктора Covariance вместо заявленного класса Conversation был передан
            // объект класса-наследника PhoneConversation. В этом классе не реализован метод Speak, однако благодаря
            // ковариантности вызывается реализация этого метода класса Conversation, находящегося выше по иерархии
            Covariance firstExample = new Covariance(new PhoneConversation());
            firstExample.CallParentMethod();

            // Здесь объявляется конкретная реализация делегата trigger с присвоением ему типа Conversation 
            ConversationsTrigger<Conversation> trigger = (inputConversation) => { inputConversation.Speak(); };

            // Благодаря контрвариантности мы можем применить действие, специфичное для родительского класса
            // Conversation для всех классов-наследников (VideoConversation и PhoneConversation), при этом сохраняя
            // допустимость вызова для них только ограниченного набора операций
            ConversationsTrigger<VideoConversation> videoTrigger = trigger;
            VideoConversation videoConversation = new VideoConversation();
            videoTrigger(videoConversation);

            ConversationsTrigger<PhoneConversation> phoneTrigger = trigger;
            PhoneConversation phoneConversation = new PhoneConversation();
            phoneTrigger(phoneConversation);
        }
    }
}