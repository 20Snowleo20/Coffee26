<script>
import logo from '../assets/image/logo.svg'
export default {
  name: 'Header',
  data() {
    return {
      logo 
    }
  }
}
</script>

<template>
  <header class="border-b-4 border-black">
    <nav
      class="max-w-7xl mx-auto flex flex-col md:flex-row items-center justify-between gap-4 px-4 md:px-6 py-4"
    >
      <div class="shrink-0 text-lg font-semibold"> Perfect Coffee Project
      </div>

      <div
        class="flex flex-wrap justify-center items-center gap-x-6 gap-y-2 text-sm font-medium"
      >
        <router-link
          to="/"
          class="transition hover:underline hover:opacity-70"
        >
          Главная
        </router-link>

        <router-link
          to="/#aboutus"
          class="transition hover:underline hover:opacity-70"
        >
          О нас
        </router-link>

        <router-link
          to="/#table"
          class="transition hover:underline hover:opacity-70"
        >
          Лидеры
        </router-link>

        <router-link
          to="/recipes"
          class="transition hover:underline hover:opacity-70"
        >
          Рецепты
        </router-link>

        <router-link
          to="/contacts"
          class="transition hover:underline hover:opacity-70"
        >
          Контакты
        </router-link>

        <router-link
          to="/faq"
          class="transition hover:underline hover:opacity-70"
        >
          FAQ
        </router-link>

        <router-link
          to="/profile"
          class="transition hover:underline hover:opacity-70"
        >
          Профиль
        </router-link>
      </div>

      <div class="shrink-0">
        <img
          :src="logo"
          alt="Логотип"
          class="h-12 md:h-20 w-auto"
        />
      </div>
    </nav>
  </header>
</template>
