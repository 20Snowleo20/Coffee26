<template>
  <section class="bg-slate-300 flex items-center justify-center min-h-screen">
    <div class="text-center px-6">
      <h1 class="text-6xl font-bold animate-bounce">404</h1>
      <h2 class="text-3xl font-semibold text-slate-700 mt-4 md:mt-6">
        Ой! Страница не найдена
      </h2>
      <p class="text-slate-700 mt-2 max-w-md mx-auto">
        Возможно, эта страница была удалена или перемещена. Попробуйте
        вернуться на главную.
      </p>

      <p class="py-8">{{ currentDate }}</p>
      
      <div class="mt-4 sm:space-x-8 space-y-6">
        <router-link 
          to="/" 
          class="inline-block bg-slate-900 text-white px-6 py-3 rounded-lg hover:bg-slate-700 transition animate-pulse"
        >
          Главная страница
        </router-link>
        
        <router-link 
          to="/contacts" 
          class="inline-block bg-gray-200 text-gray-800 px-6 py-3 rounded-lg hover:bg-gray-300 transition"
        >
          Связаться с нами
        </router-link>
      </div>
      
      <div class="mt-12">
        <p class="text-slate-900">Или воспользуйтесь навигацией:</p>
        <nav class="mt-8 space-x-12 font-semibold">

          <router-link to="/" class="hover:underline">Главная</router-link>
          <router-link to="/#aboutus" class="hover:underline">О нас</router-link>
          <router-link to="/#table" class="hover:underline">Лидеры</router-link>
          <router-link to="/page404" class="hover:underline">Рецепты</router-link>
          <router-link to="/contacts" class="hover:underline">Контакты</router-link>
          <router-link to="/faq" class="hover:underline">FAQ</router-link>
        </nav>
      </div>
    </div>

    
  </section>
</template>

<script>
export default {
  name: "Page404",
  
  // Сегодняшняя дата
  data() {
    return {
      currentDate: new Date().toLocaleDateString('ru-RU', {
        year: 'numeric',
        month: 'long',
        day: 'numeric'
      })
    };
  },
  
  mounted() {
    console.log("Страница 404 в обновленном варианте загружена");
  }
};
</script>

<style scoped>
</style>