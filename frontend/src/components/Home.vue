<script setup>
import { ref, computed, onMounted, watch } from 'vue'
import bgSky from '../assets/image/bg_sky.jpg'

const reviews = ref([])
const reviewForm = ref({
  city: '',
  coffeeShop: '',
  drink: '',
  milk: '',
  milkRating: null,
  topping: '',
  toppingRating: null,
  overallRating: null,
  bitterness: null
})

const isMilkApplicable = computed(() => {
  return reviewForm.value.drink !== 'Эспрессо' && reviewForm.value.drink !== 'Американо'
})

watch(() => reviewForm.value.drink, (newDrink) => {
  if (newDrink === 'Эспрессо' || newDrink === 'Американо') {
    reviewForm.value.milk = ''
    reviewForm.value.milkRating = null
  }
})
async function loadReviews() {

  try {

    const response =
      await fetch(
        'http://localhost:5123/reviews'
      )

    if (!response.ok)
      return

    reviews.value =
      await response.json()

  } catch (error) {

    console.error(error)
  }
}
onMounted(loadReviews)

const filters = ref({
  city: '',
  drink: '',
  milk: '',
  topping: '',
  bitterness: null
})

const filteredTable = computed(() => {
    // Сначала фильтруем ВСЕ отзывы по выбранным критериям
    let filteredReviews = [...reviews.value]
    
    // Обязательные фильтры (город и напиток)
    if (filters.value.city) {
        filteredReviews = filteredReviews.filter(
            review => review.city === filters.value.city
        )
    }
    
    if (filters.value.drink) {
        filteredReviews = filteredReviews.filter(
            review => review.drink === filters.value.drink
        )
    }
    
    // Дополнительные фильтры (только если выбраны)
    if (filters.value.milk) {
        filteredReviews = filteredReviews.filter(
            review => review.milk === filters.value.milk
        )
    }
    
    if (filters.value.topping) {
        filteredReviews = filteredReviews.filter(
            review => review.topping === filters.value.topping
        )
    }
    
    if (filters.value.bitterness !== null && filters.value.bitterness !== '') {
        filteredReviews = filteredReviews.filter(
            review => Number(review.bitterness) === Number(filters.value.bitterness)
        )
    }
    
    // Теперь группируем отфильтрованные отзывы по обязательным полям
    const grouped = {}
    
filteredReviews.forEach(review => {
    // Пропускаем отзывы без обязательных данных
    if (!review.city || !review.coffeeShop || !review.drink) {
        return
    }
    
    const key = `${review.city}-${review.coffeeShop}-${review.drink}`
    
    if (!grouped[key]) {
        grouped[key] = {
            id: key,
            drink: review.drink,
            city: review.city,
            coffeeShop: review.coffeeShop,
            scores: []
        }
    }
    
    const rating = Number(review.overallRating)
    if (!Number.isNaN(rating) && rating > 0) {
        grouped[key].scores.push(rating)
    }
})

// Вычисляем средние баллы
    const result = Object.values(grouped).map(item => ({
        ...item,
        score: item.scores.length > 0
            ? Number(
                (item.scores.reduce((a, b) => a + b, 0) / item.scores.length)
                    .toFixed(1)
              )
            : 0
    }))
    
    return result.sort((a, b) => b.score - a.score).slice(0, 10)
})
function setBitterness(value) {
  filters.value.bitterness = value
}

function resetFilters() {
  filters.value = {
    city: '',
    drink: '',
    milk: '',
    topping: '',
    bitterness: null
  }
}
async function submitReview() {

  const token =
    localStorage.getItem('token')

  if (!token) {
    alert(
      'Для отправки отзыва необходимо войти'
    )
    return
  }

  if (
    !reviewForm.value.city ||
    !reviewForm.value.coffeeShop ||
    !reviewForm.value.drink ||
    !reviewForm.value.overallRating
  ) {
    alert(
      'Заполните обязательные поля'
    )
    return
  }

  const response =
    await fetch(
      'http://localhost:5123/reviews',
      {
        method: 'POST',
        headers: {
          'Content-Type':
            'application/json',
          token
        },
        body: JSON.stringify(
          reviewForm.value
        )
      }
    )

  if (!response.ok) {
    alert(
      'Ошибка отправки отзыва'
    )
    return
  }

  await loadReviews()

  reviewForm.value = {
    city: '',
    coffeeShop: '',
    drink: '',
    milk: '',
    milkRating: null,
    topping: '',
    toppingRating: null,
    overallRating: null,
    bitterness: null
  }

  alert('Отзыв добавлен')
}
function scrollToForm() {
  document.querySelector('#reviewForm')?.scrollIntoView({ behavior: 'smooth' })
}
</script>

<template>
  <main>
    <div class="bg-cover bg-center bg-no-repeat" :style="{ backgroundImage: `url(${bgSky})` }">
      <div class="p-4">
<div class="flex flex-wrap justify-center gap-2 md:gap-4 py-2 md:py-4 mb-6">
  <router-link :to="{ path: '/recipes', hash: '#americano' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Американо
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#latte' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Латте
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#cappuchino' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Капучино
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#mocco' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Мокко
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#espresso' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Эспрессо
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#raf' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Раф
  </router-link>
  <router-link :to="{ path: '/recipes', hash: '#macchiato' }"
    class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 border-blue-300 rounded-full text-xs md:text-sm font-semibold flex justify-center items-center text-center bg-white/80 text-slate-800! hover:bg-blue-50 hover:border-blue-400 transition shadow-md">
    Макиато
  </router-link>
</div>

        <div class="my-8 md:my-16 space-y-4 md:space-y-8">
  <p class="text-lg md:text-2xl lg:text-3xl leading-relaxed md:ml-[12%]">
    Чтобы согреться, нам нужна температура
  </p>

  <p class="text-lg md:text-2xl lg:text-3xl leading-relaxed text-center">
    Чтобы насладиться, нам нужна атмосфера
  </p>

  <p class="text-lg md:text-2xl lg:text-3xl leading-relaxed md:ml-[6%]">
    Чтобы почувствовать, нам нужен
    <span class="font-semibold tracking-wide">ВКУС</span>
  </p>
</div>
        <div class="flex flex-col sm:flex-row items-center justify-between py-4 px-4 gap-4 mb-16">
          <div class="font-semibold text-center sm:text-left">
            <div>Твой отзыв действительно важен</div>
            <div class="mt-2 pl-0 md:pl-[10%] font-semibold">Лучший кофе - лучше день</div>
          </div>
          <button @click="scrollToForm"
            class="rounded-full px-4 py-2 text-white bg-slate-700 hover:bg-slate-900 active:bg-slate-500 min-w-30">
            Добавить
          </button>
        </div>
      </div>
    </div>

    <div class="flex flex-wrap items-start mt-16 gap-12" id="table">

    <aside class="w-48 text-sm space-y-8 mx-auto md:mx-0 md:ml-6">
  <div>
    <h3 class="font-semibold mb-2">Кто мы?</h3>
    <p>Сообщество любителей кофе, формирующее честный рейтинг напитков.</p>
  </div>
  <div>
    <h3 class="font-semibold mb-2">Наши приоритеты</h3>
    <p>Вкус, атмосфера, честная оценка.</p>
  </div>
  <div>
    <h3 class="font-semibold mb-2">Таблица лидеров</h3>
    <p>Топ-10 напитков по отзывам.</p>
  </div>
</aside>
      <div class="w-full md:flex-1 overflow-x-auto">
        <div class="bg-white border rounded-lg sm:min-w-50 overflow-hidden">
          <table class="w-full text-sm">
            <thead class="bg-gray-50">
              <tr>
                <th class="p-2 md:p-3 text-left font-medium">Вид напитка</th>
                <th class="p-2 md:p-3 text-left font-medium">Город</th>
                <th class="p-2 md:p-3 text-left font-medium">Кофейня</th>
                <th class="p-2 md:p-3 text-right font-medium">Балл</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in filteredTable" :key="item.id" class="border-t hover:bg-gray-50">
                <td class="p-2 md:p-3">{{ item.drink }}</td>
                <td class="p-2 md:p-3">{{ item.city }}</td>
                <td class="p-2 md:p-3">{{ item.coffeeShop }}</td>
                <td class="p-2 md:p-3 text-right font-semibold">{{ item.score }}</td>
              </tr>

              <tr v-if="filteredTable.length === 0">
                <td colspan="4" class="p-4 text-center text-gray-500">
                  {{ reviews.length === 0 ? 'Пока нет отзывов. Будьте первым!' : 'По вашим критериям ничего не найдено'
                  }}
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <aside class="w-full md:w-52">
        <div class="bg-white border rounded-lg p-3 md:p-4 space-y-3 text-sm">
          <h3 class="font-semibold text-center md:text-left">Настрой свои предпочтения</h3>

          <div>
            <label class="block mb-1 text-gray-600 text-sm">
              Город 
            </label>
            <select v-model="filters.city" class="w-full border rounded px-2 py-1 text-sm">
              <option value="">Выберите город</option>
              <option value="Москва">Москва</option>
              <option value="Санкт-Петербург">Санкт-Петербург</option>
              <option value="Пермь">Пермь</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 text-gray-600 text-sm">
              Напиток <span v-if="!filters.drink" class="text-red-500">*</span>
            </label>
            <select v-model="filters.drink" class="w-full border rounded px-2 py-1 text-sm">
              <option value="">Любой</option>
              <option value="Американо">Американо</option>
              <option value="Латте">Латте</option>
              <option value="Капучино">Капучино</option>
              <option value="Мокко">Мокко</option>
              <option value="Эспрессо">Эспрессо</option>
              <option value="Раф">Раф</option>
              <option value="Макиато">Макиато</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 text-gray-600 text-sm">Молоко</label>
            <select v-model="filters.milk" class="w-full border rounded px-2 py-1 text-sm">
              <option value="">Любое</option>
              <option value="Классическое">Классическое</option>
              <option value="Безлактозное">Безлактозное</option>
              <option value="Овсяное">Овсяное</option>
              <option value="Кокосовое">Кокосовое</option>
              <option value="Банановое">Банановое</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 text-gray-600 text-sm">Топинг</label>
            <select v-model="filters.topping" class="w-full border rounded px-2 py-1 text-sm">
              <option value="">Любой</option>
              <option value="Сахар">Сахар</option>
              <option value="Сироп">Сироп</option>
              <option value="Корица">Корица</option>
              <option value="Доп эспрессо">Доп эспрессо</option>
              <option value="Сливки">Сливки</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 text-gray-600 text-sm">Насколько нравится горчинка?</label>
            <div class="flex justify-center gap-1">
              <template v-for="i in 5" :key="i">
                <input type="radio" :name="'bitterness_scale'" :id="'bitter_' + i" :value="i"
                  v-model.number="filters.bitterness" class="hidden">
                <label :for="'bitter_' + i" @click="setBitterness(i)" :class="[
                  'w-4 h-4 rounded-full border-2 cursor-pointer transition-all',
                  filters.bitterness !== null && i <= filters.bitterness
                    ? 'bg-black border-black'
                    : 'bg-white border-gray-300 hover:border-gray-400'
                ]" :title="'Уровень ' + i"></label>
              </template>
            </div>
            <div class="text-center mt-1 text-xs text-gray-500">
              <span v-if="filters.bitterness">
                Выбрано: {{ filters.bitterness }}/5
                <button @click="filters.bitterness = null" class="ml-1 text-blue-600 hover:text-blue-800 underline"
                  title="Сбросить выбор горчинки">×</button>
              </span>
              <span v-else>Не выбрано</span>
            </div>
          </div>

          <button @click="resetFilters"
            class="w-full text-gray-700 py-2 px-4 rounded-lg border border-gray-300 hover:bg-gray-50 transition-colors mt-4">
            Сбросить всё
          </button>
        </div>
      </aside>
    </div>

    <div class="py-6 bg-slate-50 mt-6" id="reviewForm">
      <div class="max-w-3xl mx-auto px-4">

        <h2 class="text-3xl font-semibold text-center mb-8">
          Оставьте свой отзыв
        </h2>

        <div class="bg-white rounded-lg border p-6 space-y-4">

          <div>
            <label class="block mb-1 font-medium">
              Город *
            </label>

            <select v-model="reviewForm.city" class="w-full border rounded p-2">
              <option value="">Выберите город</option>
              <option>Москва</option>
              <option>Санкт-Петербург</option>
              <option>Пермь</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 font-medium">
              Название кофейни *
            </label>

            <input v-model="reviewForm.coffeeShop" type="text" class="w-full border rounded p-2" />
          </div>

          <div>
            <label class="block mb-1 font-medium">
              Напиток *
            </label>

            <select v-model="reviewForm.drink" class="w-full border rounded p-2">
              <option value="">Выберите напиток</option>
              <option>Американо</option>
              <option>Латте</option>
              <option>Капучино</option>
              <option>Мокко</option>
              <option>Эспрессо</option>
              <option>Раф</option>
              <option>Макиато</option>
            </select>
          </div>

          <div>
  <label class="block mb-1 font-medium" :class="{ 'text-gray-400': !isMilkApplicable }">
    Молоко
    <span v-if="!isMilkApplicable" class="text-xs text-gray-500 font-normal ml-2">
      (не требуется для {{ reviewForm.drink }})
    </span>
  </label>

  <select 
    v-model="reviewForm.milk" 
    :disabled="!isMilkApplicable"
    class="w-full border rounded p-2 transition-colors"
    :class="isMilkApplicable 
      ? 'bg-white text-slate-700 cursor-pointer' 
      : 'bg-gray-100 text-gray-400 cursor-not-allowed border-gray-200'"
  >
    <option value="">Любое</option>
    <option value="Классическое">Классическое</option>
    <option value="Безлактозное">Безлактозное</option>
    <option value="Овсяное">Овсяное</option>
    <option value="Кокосовое">Кокосовое</option>
    <option value="Банановое">Банановое</option>
  </select>
</div>

<div>
  <label class="block mb-1 font-medium" :class="{ 'text-gray-400': !isMilkApplicable }">
    Оценка молока (1-5)
    <span v-if="!isMilkApplicable" class="text-xs text-gray-500 font-normal ml-2">
      (не требуется для {{ reviewForm.drink }})
    </span>
  </label>

  <select 
    v-model.number="reviewForm.milkRating" 
    :disabled="!isMilkApplicable"
    class="w-full border rounded p-2 transition-colors"
    :class="isMilkApplicable 
      ? 'bg-white text-slate-700 cursor-pointer' 
      : 'bg-gray-100 text-gray-400 cursor-not-allowed border-gray-200'"
  >
    <option :value="null" disabled>Выберите оценку</option>
    <option :value="1">1</option>
    <option :value="2">2</option>
    <option :value="3">3</option>
    <option :value="4">4</option>
    <option :value="5">5</option>
  </select>
</div>
          <div>
            <label class="block mb-1 font-medium">
              Топинг
            </label>

            <select v-model="reviewForm.topping"  class="w-full border rounded p-2">
              <option value="">Любой</option>
              <option value="Сахар">Сахар</option>
              <option value="Сироп">Сироп</option>
              <option value="Корица">Корица</option>
              <option value="Доп эспрессо">Доп эспрессо</option>
              <option value="Сливки">Сливки</option>
            </select>
          </div>

          <div>
            <label class="block mb-1 font-medium">
              Оценка топинга (1-5)
            </label>

            <select v-model.number="reviewForm.toppingRating" class="w-full border rounded p-2">
    <option :value="null" disabled>Выберите оценку</option>
    <option :value="1">1</option>
    <option :value="2">2</option>
    <option :value="3">3</option>
    <option :value="4">4</option>
    <option :value="5">5</option>
  </select>
          </div>
  <div>
  <label class="block mb-1 font-medium">
    Горчинка (1-5)
  </label>

  <div class="flex justify-center gap-1">
    <template v-for="i in 5" :key="i">
      <input 
        type="radio" 
        :name="'review_bitterness_scale'" 
        :id="'review_bitter_' + i" 
        :value="i"
        v-model.number="reviewForm.bitterness" 
        class="hidden"
      >
      <label 
        :for="'review_bitter_' + i" 
        @click="reviewForm.bitterness = i" 
        :class="[
          'w-4 h-4 rounded-full border-2 cursor-pointer transition-all',
          reviewForm.bitterness !== null && i <= reviewForm.bitterness
            ? 'bg-black border-black'
            : 'bg-white border-gray-300 hover:border-gray-400'
        ]" 
        :title="'Уровень ' + i"
      ></label>
    </template>
  </div>
  
  <div class="text-center mt-1 text-xs text-gray-500">
    <span v-if="reviewForm.bitterness">
      Выбрано: {{ reviewForm.bitterness }}/5
      <button 
        @click="reviewForm.bitterness = null" 
        class="ml-1 text-blue-600 hover:text-blue-800 underline"
        title="Сбросить выбор горчинки"
      >×</button>
    </span>
    <span v-else>Не выбрано</span>
  </div>
</div>
 <div>
  <label class="block mb-1 font-medium">
    Общая оценка напитка * (1-10)
  </label>

  <div class="grid grid-cols-5 gap-2">
    <button 
      v-for="i in 10" 
      :key="i"
      type="button"
      @click="reviewForm.overallRating = i"
      :class="[
        'py-2 rounded-lg border text-sm font-semibold transition-all',
        reviewForm.overallRating === i 
          ? 'bg-slate-800 text-white border-slate-800 shadow-lg' 
          : 'bg-slate-200 text-slate-700 border-slate-300 hover:bg-slate-300 hover:border-slate-400'
      ]"
    >
      {{ i }}
    </button>
  </div>
</div>


          <button @click="submitReview" class="w-full bg-slate-700 text-white rounded p-3 hover:bg-slate-900">
            Отправить отзыв
          </button>

        </div>
      </div>
    </div>

    <div class="py-6 bg-slate-100 mt-6" id="aboutus">
      <div class="px-4 text-xl md:text-2xl font-semibold py-4 text-center">
        Немного дополнений от нас
      </div>
      <div class="mb-6 space-y-6 font-semibold py-4 px-4">
        <p class="text-left">На самом деле мы прекрасно понимаем, что вкус каждого нашего гостя особенный.</p>
        <p class="text-left">Понимаем, что многие из вас уже давно выбрали то самое место, куда всегда хочется
          возвращаться.
        </p>
        <p class="text-right">Н-но ведь счастье совершенно не в достижении цели? Счастье именно в пути...</p>
        <p class="text-right">Именно поэтому и был создан этот сайт, чтобы разделить с вами тот самый путь к счастью.
        </p>
        <p class="text-right">Путь к лучшему кофе</p>
      </div>
    </div>
  </main>
</template>

<style scoped></style>