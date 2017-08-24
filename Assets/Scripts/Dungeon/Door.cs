﻿namespace ShiftingDungeon.Dungeon
{
    using UnityEngine;

    public class Door : MonoBehaviour
    {
        /// <summary> True if this door is open and can be passed throught. </summary>
        public bool IsOpen { get; private set; }
        /// <summary> The room this door is in. </summary>
        public Room Parent { get; private set; }

        private Animator anim;
        private Collider2D trigger;
        private Room next;

        /// <summary> Initializes this door.</summary>
        /// <param name="parent"> The room this door is in. </param>
        /// <param name="next"> The room this door connects to.  Can be null.</param>
        internal void Init(Room parent, Room next)
        {
            this.anim = GetComponent<Animator>();
            this.trigger = GetComponent<Collider2D>();
            this.Parent = parent;
            this.next = next;

            if (this.next != null)
                SetOpen();
            else
                SetClosed();
        }

        /// <summary> Sets this door to be open. </summary>
        public void SetOpen()
        {
            this.anim.SetBool("open", true);
            this.trigger.enabled = true;
            this.IsOpen = true;
        }

        /// <summary> Sets this door to be closed. </summary>
        public void SetClosed()
        {
            this.anim.SetBool("open", false);
            this.trigger.enabled = false;
            this.IsOpen = false;
        }

        /// <summary> Gets the next room connected to this door. </summary>
        /// <returns> The index of the next room or -1 if not connected. </returns>
        public int GetNextRoom()
        {
            if (this.next == null)
                return -1;
            return this.next.Index;
        }
    }
}