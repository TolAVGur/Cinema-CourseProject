using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfUI.Services
{
    public class DisplayRegistry
    {
        #region -- Регистратор окон
        Dictionary<Type, Type> vmToWindowMapping = new Dictionary<Type, Type>();
        public void RegisterWindowType<VM, Win>() where Win : Window, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException($"Type {vmType.FullName} is already registered");
            vmToWindowMapping[vmType] = typeof(Win);
        }
        public void UnRegisterWindowType<VM>()
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (!vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException($"Type {vmType.FullName} is not registered");
            vmToWindowMapping.Remove(vmType);
        }
        #endregion

        #region -- Создание экземпляра окна с VM
        public Window CreateWindowInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type windowType = null;

            var vmType = vm.GetType();
            while (vmType != null && !vmToWindowMapping.TryGetValue(vmType, out windowType))
            vmType = vmType.BaseType;

            if (windowType == null)
                throw new ArgumentException(
                    $"No registered window type for argument type {vm.GetType().FullName}");
            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;
            return window;
        }
        #endregion

        #region -- Отображение окон
        Dictionary<object, Window> openWindows = new Dictionary<object, Window>();

        // -- Показать немодальное представление
        public void ShowPresentation(object vm)
        {
            if (vm == null) throw new ArgumentNullException("vm");
            if (openWindows.ContainsKey(vm)) throw new InvalidOperationException("UI for this VM is already displayed");

            var window = CreateWindowInstanceWithVM(vm);
            window.Show();
            openWindows[vm] = window;
        }

            // -- закрытие
        public void HidePresentation(object vm)
        {
            Window window;
            if (!openWindows.TryGetValue(vm, out window)) throw new InvalidOperationException("UI for this VM is not displayed");
            window.Close();
            openWindows.Remove(vm);
        }

            // -- Показать модальное представление
        public void ShowModalPresentation(object vm)
        {
            var window = CreateWindowInstanceWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Dispatcher.Invoke(() => window.ShowDialog());
        }


        #endregion


    }
}
