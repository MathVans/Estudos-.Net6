﻿using Flunt.Notifications;

namespace LojaMVC.Domain;

public abstract class Entity : Notifiable<Notification>
{
 
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string CreatedBy { get; set; }

    public string EditedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime EditedOn { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }
}
