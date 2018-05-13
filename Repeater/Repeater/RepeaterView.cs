﻿using System;
using System.Collections;
using Xamarin.Forms;

namespace XamarinForms.Plugin.Repeater
{
	public class RepeaterView : FlexLayout
    {
		private const int DefaultValue = 1;
		public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            nameof(ItemTemplate), 
            typeof(DataTemplate), 
            typeof(RepeaterView), 
            default(DataTemplate));

		public  static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource), 
            typeof(ICollection), 
            typeof(RepeaterView), 
            null, 
            BindingMode.OneWay, 
            propertyChanged: ItemsChanged);
        
        public RepeaterView()
        {
			Direction = FlexDirection.Column;
            AlignContent = FlexAlignContent.Center;
            JustifyContent = FlexJustify.Center;
		}

		public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(int),
            typeof(RepeaterView),
			DefaultValue,
            BindingMode.OneWay,
			propertyChanged: RepeatCountChanged);

		private static void RepeatCountChanged(BindableObject bindable, object oldValue, object newValue)
		{
			throw new NotImplementedException();
		}

		public int RepeatCount
        {
			get => (int)GetValue(RepeatCountProperty);
			set => SetValue(RepeatCountProperty, value);
        }
        public ICollection ItemsSource
        {
            get => (ICollection) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }
        
        protected virtual View ViewFor(object item)
        {
            View view = null;

            if (ItemTemplate != null)
            {
                var content = ItemTemplate.CreateContent();

                view = content is View ? content as View : ((ViewCell)content).View;

                view.BindingContext = item;
            }

            return view;
        }
        
        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as RepeaterView;

            if (control == null) return;

            control.Children.Clear();

            var items = (ICollection) newValue;

            if (items == null) return;

            foreach (var item in items)
            {
                control.Children.Add(control.ViewFor(item));
            }
        }
    }
}
