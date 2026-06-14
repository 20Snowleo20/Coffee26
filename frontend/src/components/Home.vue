<script setup>
import { ref, computed, onMounted } from 'vue'
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

// Вычисление рейтинга: группировка по напитку и подсчет среднего балла
const dynamicRating = computed(() => {
    if (reviews.value.length === 0) return []
    
    const grouped = {}
    
    reviews.value.forEach(review => {
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
    
    return Object.values(grouped).map(item => ({
        ...item,
        score: item.scores.length > 0
            ? Number(
                (item.scores.reduce((a, b) => a + b, 0) / item.scores.length)
                    .toFixed(1)
              )
            : 0
    }))
})

// Фильтрация и сортировка таблицы
const filteredTable = computed(() => {

    let result = [...dynamicRating.value]

    if (filters.value.city) {
        result = result.filter(
            item =>
                item.city === filters.value.city
        )
    }

    if (filters.value.drink) {
        result = result.filter(
            item =>
                item.drink === filters.value.drink
        )
    }

    return result.sort(
        (a, b) => b.score - a.score
    )
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
      <div class="bg-white/70 p-4">
        
        <div class="flex flex-wrap justify-center gap-2 md:gap-4 py-2 md:py-4 mb-6">
          <router-link to="/americano" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Американо</router-link>
          <router-link to="/latte" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Латте</router-link>
          <router-link to="/cappuccino" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Капучино</router-link>
          <router-link to="/mocco" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Мокко</router-link>
          <router-link to="/espresso" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Эспрессо</router-link>
          <router-link to="/raf" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Раф</router-link>
          <router-link to="/makiato" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Макиато</router-link>
        </div>

        <div class="mt-16 mb-16 md:space-y-12 space-y-6">
          <p class="text-2xl text-left pl-[20%]">Чтобы согреться, нам нужна температура</p>
          <p class="text-2xl text-center">Чтобы насладиться, нам нужна атмосфера</p>
          <p class="text-2xl text-left pl-[20%] mb-30">
            Чтобы почувствовать, нам нужен <span class="font-semibold">ВКУС</span>
          </p>
        </div>

        <div class="flex flex-col sm:flex-row items-center justify-between py-4 px-4 gap-4 mb-16">
          <div class="font-semibold text-center sm:text-left">
            <div>Твой отзыв действительно важен</div>
            <div class="mt-2 pl-0 md:pl-[10%] font-semibold">Лучший кофе - лучше день</div>
          </div>
          <button 
            @click="scrollToForm"
            class="rounded-full px-4 py-2 text-white bg-slate-700 hover:bg-slate-900 active:bg-slate-500 min-w-30"
          >
            Добавить
          </button>
        </div>
      </div>
    </div>

    <div class="flex flex-wrap items-start mt-16 gap-12" id="table">

      <aside class="w-48 text-sm space-y-8 ml-6">
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
                  {{ reviews.length === 0 ? 'Пока нет отзывов. Будьте первым!' : 'По вашим критериям ничего не найдено' }}
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
              Город <span v-if="!filters.city" class="text-red-500">*</span>
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
                <input 
                  type="radio" 
                  :name="'bitterness_scale'" 
                  :id="'bitter_' + i" 
                  :value="i" 
                  v-model.number="filters.bitterness"
                  class="hidden"
                >
                <label 
                  :for="'bitter_' + i"
                  @click="setBitterness(i)"
                  :class="[
                    'w-4 h-4 rounded-full border-2 cursor-pointer transition-all',
                    filters.bitterness !== null && i <= filters.bitterness
                      ? 'bg-black border-black'
                      : 'bg-white border-gray-300 hover:border-gray-400'
                  ]"
                  :title="'Уровень ' + i"
                ></label>
              </template>
            </div>
            <div class="text-center mt-1 text-xs text-gray-500">
              <span v-if="filters.bitterness">
                Выбрано: {{ filters.bitterness }}/5
                <button 
                  @click="filters.bitterness = null"
                  class="ml-1 text-blue-600 hover:text-blue-800 underline"
                  title="Сбросить выбор горчинки"
                >×</button>
              </span>
              <span v-else>Не выбрано</span>
            </div>
          </div>

          <button
            @click="resetFilters"
            class="w-full text-gray-700 py-2 px-4 rounded-lg border border-gray-300 hover:bg-gray-50 transition-colors mt-4"
          >
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

        <select
          v-model="reviewForm.city"
          class="w-full border rounded p-2"
        >
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

        <input
          v-model="reviewForm.coffeeShop"
          type="text"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Напиток *
        </label>

        <select
          v-model="reviewForm.drink"
          class="w-full border rounded p-2"
        >
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
        <label class="block mb-1 font-medium">
          Молоко
        </label>

        <input
          v-model="reviewForm.milk"
          type="text"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Оценка молока (1-5)
        </label>

        <input
          v-model.number="reviewForm.milkRating"
          type="number"
          min="1"
          max="5"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Топинг
        </label>

        <input
          v-model="reviewForm.topping"
          type="text"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Оценка топинга (1-5)
        </label>

        <input
          v-model.number="reviewForm.toppingRating"
          type="number"
          min="1"
          max="5"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Общая оценка напитка * (1-10)
        </label>

        <input
          v-model.number="reviewForm.overallRating"
          type="number"
          min="1"
          max="10"
          class="w-full border rounded p-2"
        />
      </div>

      <div>
        <label class="block mb-1 font-medium">
          Горчинка (1-5)
        </label>

        <input
          v-model.number="reviewForm.bitterness"
          type="number"
          min="1"
          max="5"
          class="w-full border rounded p-2"
        />
      </div>

      <button
        @click="submitReview"
        class="w-full bg-slate-700 text-white rounded p-3 hover:bg-slate-900"
      >
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
        <p class="text-left">Понимаем, что многие из вас уже давно выбрали то самое место, куда всегда хочется возвращаться.</p>
        <p class="text-right">Н-но ведь счастье совершенно не в достижении цели? Счастье именно в пути...</p>
        <p class="text-right">Именно поэтому и был создан этот сайт, чтобы разделить с вами тот самый путь к счастью.</p>
        <p class="text-right">Путь к лучшему кофе</p>
      </div>
    </div>
  </main>
</template>

<style scoped>
</style>