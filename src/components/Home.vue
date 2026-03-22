<template>
  <main>
    <!-- Верхняя часть с фоновым изображением + динамическая подстановка пути к картинке -->
    <div class="bg-cover bg-center bg-no-repeat" :style="{ backgroundImage: `url(${bgSky})` }">
      <div class="bg-white/70 p-4">
        
        <!-- Кнопки видов кофе (заглушки, пока без маршрутов) -->
        <div class="flex flex-wrap justify-center gap-2 md:gap-4 py-2 md:py-4 mb-6">
          <router-link to="/americano" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Американо</router-link>
           <router-link to="/latte" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Латте</router-link>
           <router-link to="/cappuccino" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Капучино</router-link>
           <router-link to="/mocco" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Мокко</router-link>
           <router-link to="/espresso" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Эспрессо</router-link>
           <router-link to="/raf" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Раф</router-link>
           <router-link to="/makiato" class="flex-1 min-w-20 max-w-30 px-2 py-3 md:px-4 md:py-6 border-2 rounded-full text-xs md:text-sm font-semibold text-center hover:bg-slate-300 transition">Макиато</router-link>
        </div>

        <!-- Текстовые блоки с цитатами -->
        <div class="mt-16 mb-16 md:space-y-12 space-y-6">
          <p class="text-2xl text-left pl-[20%]">Чтобы согреться, нам нужна температура</p>
          <p class="text-2xl text-center">Чтобы насладиться, нам нужна атмосфера</p>
          <p class="text-2xl text-left pl-[20%] mb-30">
            Чтобы почувствовать, нам нужен <span class="font-semibold">ВКУС</span>
          </p>
        </div>

        <!-- Кнопка "Добавить" (заглушка) -->
        <div class="flex flex-col sm:flex-row items-center justify-between py-4 px-4 gap-4 mb-16">
          <div class="font-semibold text-center sm:text-left">
            <div>Твой отзыв действительно важен</div>
            <div class="mt-2 pl-0 md:pl-[10%] font-semibold">Лучший кофе - лучше день</div>
          </div>
          <button class="rounded-full px-4 py-2 text-white bg-slate-700 hover:bg-slate-900 active:bg-slate-500 min-w-30">
            Добавить
          </button>
        </div>
      </div>
    </div>

    <!-- === ОСНОВНАЯ ЧАСТЬ: ТАБЛИЦА + ФИЛЬТРЫ === -->
    <div class="flex flex-wrap items-start mt-16 gap-12" id="table">

      <!-- Левый сайдбар: информация о проекте -->
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

      <!-- Центральная часть: таблица результатов -->
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
              <!-- v-for: цикл по отфильтрованным данным -->
              <!-- :key: уникальный идентификатор для Vue (обязателен) -->
              <tr v-for="item in filteredTable" :key="item.id" class="border-t hover:bg-gray-50">
                <td class="p-2 md:p-3">{{ item.drink }}</td>
                <td class="p-2 md:p-3">{{ item.city }}</td>
                <td class="p-2 md:p-3">{{ item.coffeeShop }}</td>
                <td class="p-2 md:p-3 text-right font-semibold">{{ item.score }}</td>
              </tr>
              
              <!-- Если результатов нет — показываем сообщение -->
              <tr v-if="filteredTable.length === 0">
                <td colspan="4" class="p-4 text-center text-gray-500">
                  По вашим критериям, к сожалению, ничего не найдено 
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <!-- Правый сайдбар: форма фильтрации -->
      <aside class="w-full md:w-52">
        <div class="bg-white border rounded-lg p-3 md:p-4 space-y-3 text-sm">
          <h3 class="font-semibold text-center md:text-left">Настрой свои предпочтения</h3>

          <!-- Город (ОБЯЗАТЕЛЬНОЕ ПОЛЕ) -->
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

          <!-- Напиток -->
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

          <!-- Молоко -->
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

          <!-- Топинг -->
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

          <!-- Горчинка: шкала от 1 до 5 (слева направо) -->
          <div>
            <label class="block mb-1 text-gray-600 text-sm">Насколько нравится горчинка?</label>
            <div class="flex justify-center gap-1">
              <template v-for="i in 5" :key="i">
                <!-- Скрытый radio для доступности -->
                <input 
                  type="radio" 
                  :name="'bitterness_scale'" 
                  :id="'bitter_' + i" 
                  :value="i" 
                  v-model.number="filters.bitterness"
                  class="hidden"
                >
                <!-- Видимый кружочек: закрашивается, если i <= выбранное значение -->
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
            <!-- Подпись с выбранным значением -->
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

          <!-- ЕДИНСТВЕННАЯ КНОПКА: Сбросить все фильтры -->
          <button
            @click="resetFilters"
            class="w-full text-gray-700 py-2 px-4 rounded-lg border border-gray-300 hover:bg-gray-50 transition-colors mt-4"
          >
            Сбросить всё
          </button>
        </div>
      </aside>
    </div>

    <!-- === БЛОК "О НАС" === -->
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

<script>
// Импортируем фоновое изображение (Vite обработает путь автоматически)
// Если ошибка — проверь, что файл существует: src/assets/image/bg_sky.jpg
import bgSky from '../assets/image/bg_sky.jpg'

export default {
  name: 'Home',
  
  // === ДАННЫЕ КОМПОНЕНТА ===
  data() {
    return {
      bgSky, // Фоновое изображение
      
      // Фильтры пользователя (изначальные пустые значения)
      filters: {
        city: '',
        drink: '',
        milk: '',
        topping: '',
        bitterness: null
      },
      
      // === ФУЛЛ-ТАБЛИЦА (40 записей) ===
      // Скрытые данные, пользователь видит только отфильтрованный результат
      fullTable: [
        // Москва (15)
        { id: 1, drink: 'Латте', city: 'Москва', coffeeShop: 'Starders', milk: 'Классическое', topping: 'Сахар', bitterness: 3, score: 9.1 },
        { id: 2, drink: 'Капучино', city: 'Москва', coffeeShop: 'Cofpax', milk: 'Классическое', topping: 'Корица', bitterness: 4, score: 8.8 },
        { id: 3, drink: 'Раф', city: 'Москва', coffeeShop: 'One pack', milk: 'Классическое', topping: 'Сироп', bitterness: 2, score: 8.6 },
        { id: 4, drink: 'Американо', city: 'Москва', coffeeShop: 'Starders', milk: '', topping: '', bitterness: 5, score: 8.5 },
        { id: 5, drink: 'Эспрессо', city: 'Москва', coffeeShop: 'Cofpax', milk: '', topping: '', bitterness: 5, score: 8.4 },
        { id: 6, drink: 'Латте', city: 'Москва', coffeeShop: 'One pack', milk: 'Овсяное', topping: 'Сироп', bitterness: 3, score: 8.3 },
        { id: 7, drink: 'Капучино', city: 'Москва', coffeeShop: 'Starders', milk: 'Безлактозное', topping: 'Сахар', bitterness: 4, score: 8.2 },
        { id: 8, drink: 'Мокко', city: 'Москва', coffeeShop: 'Cofpax', milk: 'Классическое', topping: 'Сливки', bitterness: 2, score: 8.1 },
        { id: 9, drink: 'Макиато', city: 'Москва', coffeeShop: 'One pack', milk: 'Классическое', topping: '', bitterness: 4, score: 8.0 },
        { id: 10, drink: 'Латте', city: 'Москва', coffeeShop: 'Starders', milk: 'Кокосовое', topping: 'Сироп', bitterness: 3, score: 7.9 },
        { id: 11, drink: 'Раф', city: 'Москва', coffeeShop: 'Cofpax', milk: 'Классическое', topping: 'Корица', bitterness: 2, score: 7.8 },
        { id: 12, drink: 'Американо', city: 'Москва', coffeeShop: 'One pack', milk: '', topping: '', bitterness: 5, score: 7.7 },
        { id: 13, drink: 'Капучино', city: 'Москва', coffeeShop: 'Starders', milk: 'Овсяное', topping: 'Сахар', bitterness: 3, score: 7.6 },
        { id: 14, drink: 'Эспрессо', city: 'Москва', coffeeShop: 'One pack', milk: '', topping: '', bitterness: 4, score: 7.5 },
        { id: 15, drink: 'Латте', city: 'Москва', coffeeShop: 'Cofpax', milk: 'Банановое', topping: 'Сливки', bitterness: 2, score: 7.4 },
        
        // Санкт-Петербург (15)
        { id: 16, drink: 'Латте', city: 'Санкт-Петербург', coffeeShop: 'Coffee House', milk: 'Классическое', topping: 'Сахар', bitterness: 3, score: 9.0 },
        { id: 17, drink: 'Капучино', city: 'Санкт-Петербург', coffeeShop: 'Surf Coffee', milk: 'Овсяное', topping: 'Корица', bitterness: 4, score: 8.9 },
        { id: 18, drink: 'Раф', city: 'Санкт-Петербург', coffeeShop: 'Doubles', milk: 'Классическое', topping: 'Сироп', bitterness: 2, score: 8.7 },
        { id: 19, drink: 'Американо', city: 'Санкт-Петербург', coffeeShop: 'Coffee House', milk: '', topping: '', bitterness: 5, score: 8.5 },
        { id: 20, drink: 'Эспрессо', city: 'Санкт-Петербург', coffeeShop: 'Surf Coffee', milk: '', topping: '', bitterness: 5, score: 8.4 },
        { id: 21, drink: 'Латте', city: 'Санкт-Петербург', coffeeShop: 'Doubles', milk: 'Кокосовое', topping: 'Сироп', bitterness: 3, score: 8.3 },
        { id: 22, drink: 'Капучино', city: 'Санкт-Петербург', coffeeShop: 'Coffee House', milk: 'Классическое', topping: 'Сахар', bitterness: 4, score: 8.2 },
        { id: 23, drink: 'Мокко', city: 'Санкт-Петербург', coffeeShop: 'Surf Coffee', milk: 'Классическое', topping: 'Сливки', bitterness: 2, score: 8.1 },
        { id: 24, drink: 'Макиато', city: 'Санкт-Петербург', coffeeShop: 'Doubles', milk: 'Безлактозное', topping: '', bitterness: 4, score: 8.0 },
        { id: 25, drink: 'Латте', city: 'Санкт-Петербург', coffeeShop: 'Coffee House', milk: 'Овсяное', topping: 'Корица', bitterness: 3, score: 7.9 },
        { id: 26, drink: 'Раф', city: 'Санкт-Петербург', coffeeShop: 'Surf Coffee', milk: 'Классическое', topping: 'Сахар', bitterness: 2, score: 7.8 },
        { id: 27, drink: 'Американо', city: 'Санкт-Петербург', coffeeShop: 'Doubles', milk: '', topping: '', bitterness: 5, score: 7.7 },
        { id: 28, drink: 'Капучино', city: 'Санкт-Петербург', coffeeShop: 'Coffee House', milk: 'Банановое', topping: 'Сироп', bitterness: 3, score: 7.6 },
        { id: 29, drink: 'Эспрессо', city: 'Санкт-Петербург', coffeeShop: 'Surf Coffee', milk: '', topping: '', bitterness: 4, score: 7.5 },
        { id: 30, drink: 'Латте', city: 'Санкт-Петербург', coffeeShop: 'Doubles', milk: 'Классическое', topping: 'Сливки', bitterness: 2, score: 7.4 },
        
        // Пермь (10)
        { id: 31, drink: 'Латте', city: 'Пермь', coffeeShop: 'Кофеин', milk: 'Классическое', topping: 'Сахар', bitterness: 3, score: 8.8 },
        { id: 32, drink: 'Капучино', city: 'Пермь', coffeeShop: 'More Coffee', milk: 'Овсяное', topping: 'Корица', bitterness: 4, score: 8.6 },
        { id: 33, drink: 'Раф', city: 'Пермь', coffeeShop: 'Кофеин', milk: 'Классическое', topping: 'Сироп', bitterness: 2, score: 8.4 },
        { id: 34, drink: 'Американо', city: 'Пермь', coffeeShop: 'More Coffee', milk: '', topping: '', bitterness: 5, score: 8.2 },
        { id: 35, drink: 'Эспрессо', city: 'Пермь', coffeeShop: 'Кофеин', milk: '', topping: '', bitterness: 5, score: 8.1 },
        { id: 36, drink: 'Латте', city: 'Пермь', coffeeShop: 'More Coffee', milk: 'Кокосовое', topping: 'Сироп', bitterness: 3, score: 8.0 },
        { id: 37, drink: 'Капучино', city: 'Пермь', coffeeShop: 'Кофеин', milk: 'Классическое', topping: 'Сахар', bitterness: 4, score: 7.9 },
        { id: 38, drink: 'Мокко', city: 'Пермь', coffeeShop: 'More Coffee', milk: 'Классическое', topping: 'Сливки', bitterness: 2, score: 7.8 },
        { id: 39, drink: 'Макиато', city: 'Пермь', coffeeShop: 'Кофеин', milk: 'Безлактозное', topping: '', bitterness: 4, score: 7.7 },
        { id: 40, drink: 'Латте', city: 'Пермь', coffeeShop: 'More Coffee', milk: 'Овсяное', topping: 'Корица', bitterness: 3, score: 7.6 }
      ]
    }
  },
  
  // === ВЫЧИСЛЯЕМЫЕ СВОЙСТВА ===
  computed: {
    // Отфильтрованная таблица: автоматически пересчитывается при изменении filters
    filteredTable() {
      // === НОВАЯ ЛОГИКА ===
      
      // Если фильтры не выбраны — показываем топ-10 по баллам из ВСЕХ данных
      if (!this.filters.city && !this.filters.drink) {
        return this.fullTable
          .slice()  // Копируем массив, чтобы не мутировать оригинал
          .sort((a, b) => b.score - a.score)  // Сортируем по баллу (убывание)
          .slice(0, 10)  // Берём топ-10
      }
      
      // Если выбраны фильтры — применяем фильтрацию
      let result = this.fullTable
      
      // Фильтр по городу (если выбран)
      if (this.filters.city) {
        result = result.filter(item => item.city === this.filters.city)
      }
      
      // Фильтр по напитку (если выбран)
      if (this.filters.drink) {
        result = result.filter(item => item.drink === this.filters.drink)
      }
      
      // Считаем совпадения для дополнительных фильтров
      result = result.map(item => {
        let matches = 0
        
        // Молоко
        if (this.filters.milk) {
          if (item.milk === this.filters.milk || item.milk === '') {
            matches++
          }
        }
        
        // Топинг
        if (this.filters.topping) {
          if (item.topping === this.filters.topping || item.topping === '') {
            matches++
          }
        }
        
        // Горчинка
        if (this.filters.bitterness !== null) {
          if (!item.bitterness || item.bitterness === this.filters.bitterness) {
            matches++
          }
        }
        
        return { ...item, _matches: matches }
      })
      
      // Сортировка: сначала по совпадениям, потом по баллу
      result.sort((a, b) => {
        if (b._matches !== a._matches) {
          return b._matches - a._matches
        }
        return b.score - a.score
      })
      
      // Возвращаем топ-10
      return result.slice(0, 10)
    }
  },
  
  // === МЕТОДЫ ===
  methods: {
    // Устанавливает значение горчинки для шкалы
    setBitterness(value) {
      this.filters.bitterness = value
    },
    
    // Сбрасывает все фильтры к начальным значениям
    resetFilters() {
      this.filters = {
        city: '',
        drink: '',
        milk: '',
        topping: '',
        bitterness: null
      }
    }
  }
}
</script>

<style scoped>
/* Локальные стили компонента (не влияют на Tailwind-классы) */
</style>