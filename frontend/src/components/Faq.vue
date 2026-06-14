<template>
  <div>
    <main
      class="text-slate-700 bg-cover bg-center bg-no-repeat"
      :style="{ backgroundImage: `url(${bgskyandriver})` }"
    >
      <div class="bg-white/50 p-4">
        
        <section>
          <h1 class="text-center py-6 md:text-2xl text-sm font-semibold">
            Часто задаваемые вопросы
          </h1>
        </section>

        <section class="space-y-6">

          <article>
            <h2 class="px-6 py-2 md:text-xl text-center md:text-left">
              <span class="border-slate-900 border-2 rounded-full px-4 py-2 inline-block">
                Как оставить отзыв?
              </span>
            </h2>
            <p class="sm:text-left text-center md:px-6 px-4 md:text-xl text-sm font-semibold">
              На&nbsp;главной странице расположена кнопка добавить, при нажатии на&nbsp;нее вы&nbsp;переноситесь в&nbsp;раздел заполнения формы отзыва. <br>
              Для более точного формирования отзыва необходимо заполнение все представленных полей. <br>
              Если вы&nbsp;спешите или не&nbsp;хотите тратить время, можно заполнить лишь обязательные поля и&nbsp;этого уже будет достаточно.
            </p>
          </article>

          <article>
            <h2 class="px-6 py-2 md:text-xl text-center md:text-left">
              <span class="border-slate-900 border-2 rounded-full px-4 py-2 inline-block">
                Как происходит подсчет баллов?
              </span>
            </h2>
            <p class="sm:text-left text-center md:px-6 px-4 md:text-xl text-sm font-semibold">
              Подсчет баллов производится по&nbsp;заранее разработанной формуле, результат вычисления которой конвертируется в&nbsp;балл по&nbsp;десятибалльной шкале. <br>
              Подобный метод подсчета помогает нам учитывать не&nbsp;только количество факторов, но&nbsp;и&nbsp;их&nbsp;важность для посетителей кофеен.
            </p>
          </article>

          <article>
            <h2 class="px-6 py-2 md:text-xl text-center md:text-left">
              <span class="border-slate-900 border-2 rounded-full px-4 py-2 inline-block">
                Что такое таблица лидеров?
              </span>
            </h2>
            <p class="sm:text-left text-center md:px-6 px-4 md:text-xl text-sm font-semibold">
              Таблица лидеров это таблица с&nbsp;лучшими кофейными напитками согласно рейтингу нашего сайта. <br>
              Таблица обновляется ежедневно с&nbsp;учетом новых отзывов наших читателей. Более высокое место в&nbsp;рейтинге соответсвует более высоким оценкам. <br>
              Если&nbsp;же оценки у&nbsp;различных позиций одинаковые, более высокое место занимает напиток с&nbsp;большим количеством голосов.
            </p>
          </article>

          <article>
            <h2 class="px-6 py-2 md:text-xl text-center md:text-left">
              <span class="border-slate-900 border-2 rounded-full px-4 py-2 inline-block">
                Как отфильтровать таблицу лидеров по&nbsp;предпочтениям?
              </span>
            </h2>
            <p class="sm:text-left text-center md:px-6 px-4 md:text-xl text-sm font-semibold">
              Фильтрация таблицы лидеров позволяет получить персональные рекомендации по&nbsp;напиткам. <br>
              Данная функция реализуется при помощи отдельного блока с&nbsp;параметрами (справа от&nbsp;таблицы), который читателю необходимо заполнить. <br>
              Для качественной фильтрации — качественных рекомендаций рекомендуется заполнить все интересующие вас блоки.
            </p>
          </article>

          <article>
            <h2 class="px-6 py-2 md:text-xl text-center md:text-left">
              <span class="border-slate-900 border-2 rounded-full px-4 py-2 inline-block">
                Как с&nbsp;нами связаться?
              </span>
            </h2>
            <p class="sm:text-left text-center md:px-6 px-4 md:text-xl text-sm font-semibold">
              Связь с&nbsp;нами возможна при помощи стандартной формы, доступной в&nbsp;разделе &laquo;Контакты&raquo;. <br>
              Если вам необходимо оставить более обширный комментарий просьба указать это в&nbsp;текстовом блоке формы, мы&nbsp;обязательно с&nbsp;вами свяжемся! <br>
              Номер телефона наших маркетологов указан в&nbsp;самом низу всех страниц сайта.
            </p>
          </article>

        </section>
      </div>
    </main>
  </div>
</template>

<script>
import bgskyandriver from '../assets/image/bg_skyandriver.jpg'
export default {
  name: "Faq",
data() {
    return {
      bgskyandriver, 
    };
  },
  
  mounted() {
    console.log("Страница FAQ загружена");
  }
};
</script>

<style scoped>
</style>