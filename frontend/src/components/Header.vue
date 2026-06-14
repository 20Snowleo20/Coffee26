<template>
  <header class="border-b-4 border-black">
    <nav class="flex flex-col md:flex-row justify-between gap-3 md:gap-6 text-sm font-medium p-4 md:p-6 mb-4">
      <div class="text-center md:text-left">Perfect Coffee Project</div>
      <div class="flex flex-wrap justify-center gap-2 md:gap-6">
        <router-link to="/" class="hover:underline">Главная</router-link>
        <router-link to="/#aboutus" class="hover:underline">О нас</router-link>
        <router-link to="/#table" class="hover:underline">Лидеры</router-link>
        <router-link to="/Page404" class="hover:underline">Рецепты</router-link>
        <router-link to="/contacts" class="hover:underline">Контакты</router-link>
        <router-link to="/faq" class="hover:underline">FAQ</router-link>
        <router-link to="/profile"> Профиль </router-link>
        <router-link to="/login">Вход</router-link>
        <router-link to="/register">  Регистрация </router-link>
      </div>
      <div class="text-center md:text-right">Logo</div>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'Header'
}
</script>